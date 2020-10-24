using AutoDbdFlexerEx.ViewModel;
using System;
using System.Windows;

namespace AutoDbdFlexerEx.View
{
    public partial class SettingsWindow : Window
    {
        public SettingsWindow(ApplicationViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;

            foreach (var corner in Enum.GetValues(typeof(ScreenCorners)))
            {
                StatusWindowCornerSelector.Items.Add(corner);
            }
        }
    }
}
