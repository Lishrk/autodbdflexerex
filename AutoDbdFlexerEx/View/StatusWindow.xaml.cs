using AutoDbdFlexerEx.ViewModel;
using System.Windows;
using System.Windows.Forms;

namespace AutoDbdFlexerEx.View
{
    public partial class StatusWindow : Window
    {
        public StatusWindow(ApplicationViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);

            this.Left = Screen.PrimaryScreen.Bounds.Right - this.ActualWidth;
            this.Top = Screen.PrimaryScreen.Bounds.Bottom - this.ActualHeight;
        }
    }
}
