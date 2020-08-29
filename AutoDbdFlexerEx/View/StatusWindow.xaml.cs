using AutoDbdFlexerEx.ViewModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

namespace AutoDbdFlexerEx.View
{
    public partial class StatusWindow : Window
    {
        private ApplicationViewModel viewModel;

        public StatusWindow(ApplicationViewModel viewModel)
        {
            InitializeComponent();

            DataContext = this.viewModel = viewModel;

            viewModel.ViewSettings.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "StatusWindowPosition")
                {
                    UpdatePosition();
                }
            };
        }
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);

            UpdatePosition();
        }
        private void UpdatePosition()
        {
            switch (viewModel.ViewSettings.StatusWindowPosition)
            {
                case ScreenCorners.LeftBottom:
                    this.Left = 0;
                    this.Top = Screen.PrimaryScreen.Bounds.Bottom - this.ActualHeight;
                    break;
                case ScreenCorners.RightBottom:
                    this.Left = Screen.PrimaryScreen.Bounds.Right - this.ActualWidth;
                    this.Top = Screen.PrimaryScreen.Bounds.Bottom - this.ActualHeight;
                    break;
                case ScreenCorners.LeftTop:
                    this.Left = 0;
                    this.Top = 0;
                    break;
                case ScreenCorners.RightTop:
                    this.Left = Screen.PrimaryScreen.Bounds.Right - this.ActualWidth;
                    this.Top = 0;
                    break;
            }
        }
    }
}