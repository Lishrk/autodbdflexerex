using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace AutoDbdFlexerEx.ViewModel
{
    public class ViewSettings : INotifyPropertyChanged
    {
        private bool _ShowStatusWindow;
        private ScreenCorners _StatusWindowPosition;
        private Color _StatusWindowTextColor;
        private int _StatusWindowTextFontSize;
        public event PropertyChangedEventHandler PropertyChanged;

        public bool ShowStatusWindow
        {
            get
            {
                return _ShowStatusWindow;
            }
            set
            {
                _ShowStatusWindow = value;
                OnPropertyChanged();
            }
        }
        public ScreenCorners StatusWindowPosition
        {
            get
            {
                return _StatusWindowPosition;
            }
            set
            {
                _StatusWindowPosition = value;
                OnPropertyChanged();
            }
        }
        public Color StatusWindowTextColor
        {
            get
            {
                return _StatusWindowTextColor;
            }
            set
            {
                _StatusWindowTextColor = value;
                _StatusWindowTextColor.A = byte.MaxValue;
                OnPropertyChanged();
            }
        }
        public int StatusWindowTextFontSize
        {
            get
            {
                return _StatusWindowTextFontSize;
            }
            set
            {
                _StatusWindowTextFontSize = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public ViewSettings()
        {
            ShowStatusWindow = true;
            StatusWindowPosition = ScreenCorners.RightBottom;
            StatusWindowTextColor = Colors.Lime;
            StatusWindowTextFontSize = 20;
        }
    }
}
