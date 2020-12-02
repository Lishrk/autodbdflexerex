using AutoDbdFlexerEx.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoDbdFlexerEx.ViewModel
{
    public class ApplicationViewModel
    {
        private readonly KeyboardHook keyboardHook;

        public ViewSettings ViewSettings { get; private set; }
        public IReadOnlyList<ActionConfig> Configs { get; private set; }
        public IReadOnlyList<IFlexAction> Actions { get; }

        public ApplicationViewModel()
        {
            try
            {
                Load();
            }
            catch
            {
                ViewSettings = new ViewSettings();
            }

            Actions = Assembly.GetExecutingAssembly()
                  .GetTypes()
                  .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(FlexAction<>))
                  .Select(type => type.GetConstructor(new Type[0]))
                  .Select(constructor => (IFlexAction)constructor.Invoke(new object[0]))
                  .ToList();

            foreach (var action in Actions)
            {
                foreach (var config in Configs)
                {
                    if (action.Config.GetType() == config.GetType())
                    {
                        action.Config = config;
                        break;
                    }
                }
            }
            Configs = Actions.Select(action => action.Config).ToList();

            keyboardHook = new KeyboardHook();
            keyboardHook.KeyDown += (s, e) =>
            {
                foreach (var action in Actions)
                    if (action.Config.Activator == e.KeyCode)
                        action.Toggle();
            };

            keyboardHook.Hook();
            App.Current.Exit += (s, e) => Save();
        }
        private void Load()
        {
            ViewSettings = Settings.Data.GetValue("view").ToObject<ViewSettings>() ?? new ViewSettings();
            Configs = Settings.Data.GetValue("actions").ToObject<IReadOnlyList<ActionConfig>>(new JsonSerializer() { TypeNameHandling = TypeNameHandling.All });
        }
        private void Save()
        {
            Settings.Data.AddOrReplace("view", JToken.FromObject(ViewSettings));
            Settings.Data.AddOrReplace("actions", JToken.FromObject(Configs, new JsonSerializer() { TypeNameHandling = TypeNameHandling.All }));
            Settings.Save();
        }
    }
}
