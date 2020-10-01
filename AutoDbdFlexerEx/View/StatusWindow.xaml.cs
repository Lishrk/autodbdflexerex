using AutoDbdFlexerEx.ViewModel;
using System;
using System.Windows;
using System.Windows.Forms;

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

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
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
                    Left = 0;
                    Top = Screen.PrimaryScreen.Bounds.Bottom - ActualHeight;
                    break;
                case ScreenCorners.RightBottom:
                    Left = Screen.PrimaryScreen.Bounds.Right - ActualWidth;
                    Top = Screen.PrimaryScreen.Bounds.Bottom - ActualHeight;
                    break;
                case ScreenCorners.LeftTop:
                    Left = 0;
                    Top = 0;
                    break;
                case ScreenCorners.RightTop:
                    Left = Screen.PrimaryScreen.Bounds.Right - ActualWidth;
                    Top = 0;
                    break;
            }
        }
    }
}