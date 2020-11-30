using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace AutoDbdFlexerEx.Model.Updater
{
    public static class Updater
    {
        public static void TryUpdate()
        {
            if(Settings.Data["FirstLaunch"] == null)
            {
                Settings.Data.Add("FirstLaunch", false);
                MessageBox.Show("Программа в первый раз проверяет наличие обновлений.\nВозможно брандмауэр Windows (файрвол) спросит вас, нужно ли разрешать программе доступ к интернету. Нажмите \"Да\"", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            UpdateCheckerResult updateCheckerResult = UpdateChecker.CheckForUpdates();

            if (updateCheckerResult.Success)
            {
                if(updateCheckerResult.CanUpdate)
                {
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
            else
            {
                MessageBox.Show("Не удалось проверить наличие обновлений.\nВозможно у вас нет доступа к интернету, или вы запретили программе доступ к нему через брандмауэр (файрвол).", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
