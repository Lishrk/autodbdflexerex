using AutoDbdFlexerEx.ViewModel;
using System;
using System.Windows;

namespace AutoDbdFlexerEx.View
{
    public partial class MainWindow : Window
    {
        private readonly ApplicationViewModel viewModel;

        public MainWindow()
        {
            DataContext = viewModel = new ApplicationViewModel();

            InitializeComponent();

            new StatusWindow(viewModel).Show();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }
        private void ShowAbout(object sender, RoutedEventArgs e)
        {
            AboutWindow.ShowAbout();
        }
        private void OpenSettings(object sender, RoutedEventArgs e)
        {
            SettingsWindow settings = new SettingsWindow(viewModel);
            settings.ShowDialog();
        }
    }
}
