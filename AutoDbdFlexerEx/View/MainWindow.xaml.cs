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
            InitializeComponent();

            DataContext = viewModel = new ApplicationViewModel();

            new StatusWindow(viewModel).Show();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }

        private void ShowAbout(object sender, RoutedEventArgs e)
        {
            About.ShowAbout();
        }

        private void OpenSettings(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings(viewModel);
            settings.ShowDialog();
        }
    }
}
