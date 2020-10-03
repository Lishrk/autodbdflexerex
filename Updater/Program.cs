using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Linq;

namespace Updater
{
    class Program
    {
        static void Main(string[] args)
        {
            // args[0] - путь к текущему файлу
            // args[1] - путь к скачанному обновлённому файлу
            // args[2] - имя родительского процесса

#if DEBUG
            System.Threading.Thread.Sleep(20000);
#endif

            try
            {
                Process.GetProcessesByName(args[2]).FirstOrDefault()?.WaitForExit();
                File.Copy(args[1], args[0], true);
                File.Delete(args[1]);
                Process.Start(args[0]);
            }
            catch
            {
                MessageBox.Show("Ошибка обновления.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
