using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;

namespace AutoDbdFlexerEx.View
{
    public partial class AboutWindow : Window
    {
        private AboutWindow()
        {
            InitializeComponent();

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            Header.Text = $"AutoDbdFlexerEx v{version}";
            Header.ToolTip = (DateTime.Now - new DateTime(2000, 1, 1).AddDays(version.Build).AddSeconds(version.Revision * 2)).Days + " дней назад";
        }

        public static void ShowAbout()
        {
            AboutWindow about = new AboutWindow();
            about.ShowDialog();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.AbsoluteUri);
        }
    }
}
