using AutoDbdFlexerEx.Model;
using AutoDbdFlexerEx.Model.Updater;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

namespace AutoDbdFlexerEx
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Увеличение скорости запуска приложения
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.AboveNormal;

            // Если программа уже запущена, не нужно открывать ещё одну
            Process currentProcess = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(currentProcess.ProcessName);
            if (processes.Length > 1)
            {
                foreach (var process in processes)
                {
                    if (process.Id != currentProcess.Id)
                    {
                        WinAPIHelper.SetForegroundWindow(process.MainWindowHandle);
                    }
                }
                Environment.Exit(0);
            }

            Task.Run(Updater.TryUpdate);
        }
    }
}
