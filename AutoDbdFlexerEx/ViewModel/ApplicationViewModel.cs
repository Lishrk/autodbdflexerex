using AutoDbdFlexerEx.Model;
using AutoDbdFlexerEx.Model.Actions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoDbdFlexerEx.ViewModel
{
    public class ApplicationViewModel
    {
        public ViewSettings ViewSettings { get; private set; }

        public Wiggle Wiggle { get; private set; }
        public TBag TBag { get; private set; }
        public HookResistance HookResistance { get; private set; }

        public IEnumerable<FlexAction> AllActions { get; }
        private readonly KeyboardHook keyboardHook;

        public ApplicationViewModel()
        {
            try
            {
                Load();
            }
            catch
            {
                Wiggle = new Wiggle();
                TBag = new TBag() { Cooldown = 100, Press = 100 };
                HookResistance = new HookResistance();
                ViewSettings = new ViewSettings();
            }

            AllActions = typeof(ApplicationViewModel).GetProperties()
                .Where(p => p.PropertyType.BaseType == typeof(FlexAction))
                .Select(p => (FlexAction)p.GetValue(this));

            keyboardHook = new KeyboardHook();
            keyboardHook.KeyDown += (s, e) =>
            {
                foreach (var action in AllActions)
                {
                    if (action.Activator == e.KeyCode)
                    {
                        action.Toggle();
                    }
                }
            };
            keyboardHook.Hook();

            App.Current.Exit += (s, e) =>
            {
                Save();
            };
        }
        private void Load()
        {
            ViewSettings = Settings.Data.GetValue("view").ToObject<ViewSettings>() ?? new ViewSettings();
            var enumerator = typeof(ApplicationViewModel).GetProperties().Where(p => p.PropertyType.BaseType == typeof(FlexAction)).GetEnumerator();
            foreach (var savedAction in Settings.Data.GetValue("actions"))
            {
                if (!enumerator.MoveNext())
                {
                    throw new Exception();
                }

                enumerator.Current.SetValue(this, savedAction.ToObject(enumerator.Current.PropertyType));
            }
        }
        private void Save()
        {
            Settings.Data.AddOrReplace("actions", JToken.FromObject(AllActions));
            Settings.Data.AddOrReplace("view", JToken.FromObject(ViewSettings));
            Settings.Save();
        }
    }
}
