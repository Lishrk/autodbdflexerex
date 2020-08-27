using AutoDbdFlexerEx.Model;
using AutoDbdFlexerEx.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoDbdFlexerEx.View
{
    public partial class MainWindow : Window
    {
        private readonly StatusWindow status;
        private readonly ApplicationViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = viewModel = new ViewModel.ApplicationViewModel();

            status = new StatusWindow(viewModel);
            status.Show();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            status.Close();
        }
    }
}
