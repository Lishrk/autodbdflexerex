using AutoDbdFlexerEx.ViewModel;
using System;
using System.Windows;
using System.Windows.Input;

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
            AboutWindow.ShowAbout();
        }
        private void OpenSettings(object sender, RoutedEventArgs e)
        {
            SettingsWindow settings = new SettingsWindow(viewModel);
            settings.ShowDialog();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ((ICommand)viewModel.Update).Execute(null);
        }
    }
}
