using AutoDbdFlexerEx.Model;
using AutoDbdFlexerEx.Model.Actions;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace AutoDbdFlexerEx.ViewModel
{
    public class ApplicationViewModel
    {
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
            catch (Exception e)
            {
                Wiggle = new Wiggle();
                TBag = new TBag() { Cooldown = 100, Press = 100 };
                HookResistance = new HookResistance();
            }

            AllActions = typeof(ApplicationViewModel).GetProperties()
                .Where(p => p.PropertyType.BaseType == typeof(FlexAction))
                .Select(p => (FlexAction)p.GetValue(this));

            keyboardHook = new KeyboardHook();
            keyboardHook.OnKeyDown += (s, e) =>
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

            App.Current.Exit += (s, e) => Save();
        }

        private void Load()
        {
            var enumerator = typeof(ApplicationViewModel).GetProperties().Where(p => p.PropertyType.BaseType == typeof(FlexAction)).GetEnumerator();
            foreach (var savedAction in JsonConvert.DeserializeObject<List<JObject>>(Properties.Settings.Default.Data))
            {
                if (!enumerator.MoveNext()) throw new Exception();
                enumerator.Current.SetValue(this, JsonConvert.DeserializeObject(savedAction.ToString(), enumerator.Current.PropertyType));
            }
        }

        private void Save()
        {
            Properties.Settings.Default.Data = JsonConvert.SerializeObject(AllActions);
            Properties.Settings.Default.Save();
        }
    }
}
