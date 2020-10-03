using AutoDbdFlexerEx.Model;
using System;
using System.Diagnostics;
using System.Windows;

namespace AutoDbdFlexerEx
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Process currentProcess = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(currentProcess.ProcessName);
            if (processes.Length > 1)
            {
                foreach(var process in processes)
                {
                    if (process.Id != currentProcess.Id)
                    {
                        WinAPIHelper.SetForegroundWindow(process.MainWindowHandle);
                    }
                }
                Environment.Exit(0);
            }
        }
    }
}
