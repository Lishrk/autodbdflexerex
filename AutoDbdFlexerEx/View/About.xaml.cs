using System.Diagnostics;
using System.Windows;

namespace AutoDbdFlexerEx.View
{
    public partial class About : Window
    {
        private About()
        {
            InitializeComponent();
        }

        public static void ShowAbout()
        {
            About about = new About();
            about.ShowDialog();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.AbsoluteUri);
        }
    }
}
