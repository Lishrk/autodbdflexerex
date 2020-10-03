using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace AutoDbdFlexerEx.Model.Updater
{
    public static class Updater
    {
        public static void Update(UpdateCheckerResult updateCheckerResult)
        {
            if (!updateCheckerResult.Success || !updateCheckerResult.CanUpdate) throw new InvalidOperationException();
            string updaterPath = Path.Combine(Path.GetTempPath(), "AutoDbdFlexerExUpdater.exe");
            string updaterResourceName = Assembly.GetExecutingAssembly().GetManifestResourceNames().Single(str => str.EndsWith("Updater.exe"));
            using (var updaterResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(updaterResourceName))
            using (var fs = new FileStream(updaterPath, FileMode.Create))
            {
                int bytesRead = 0;
                byte[] buffer = new byte[1024];
                while ((bytesRead = updaterResourceStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    fs.Write(buffer, 0, bytesRead);
                }
            }
            MessageBox.Show("AutoDbdFlexerEx будет обновлён и автоматически перезапущен", "Обновление", MessageBoxButton.OK);
            Process.Start(updaterPath, $"{Assembly.GetExecutingAssembly().Location} {updateCheckerResult.UpdatedFilePath} {Process.GetCurrentProcess().ProcessName}");
            Application.Current.Dispatcher.Invoke(Application.Current.Shutdown);
        }
    }
}
