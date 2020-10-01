using System;
using System.Reflection;
using System.Windows;

namespace AutoDbdFlexerEx
{
    public partial class App : Application
    {
        private void OnStartup(object s, StartupEventArgs e)
        {
            AppDomain.CurrentDomain.AssemblyResolve += (s1, e1) =>
            {
                if (e1.Name.Substring(0, e1.Name.IndexOf(",")) == "Newtonsoft.Json")
                {
                    return Assembly.Load(AutoDbdFlexerEx.Properties.Resources.Newtonsoft_Json);
                }
                return null;
            };
        }
    }
}
