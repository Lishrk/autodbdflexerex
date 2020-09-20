using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using System.Windows.Media;

namespace AutoDbdFlexerEx.ViewModel
{
    public class ViewSettings : INotifyPropertyChanged
    {
        private bool _ShowStatusWindow;
        private ScreenCorners _StatusWindowPosition;
        private Color _StatusWindowTextColor;
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

        private void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private ViewSettings()
        {
            ShowStatusWindow = true;
            StatusWindowPosition = ScreenCorners.RightBottom;
        }

        public void Save()
        {
            Properties.Settings.Default.ViewSettings = JsonConvert.SerializeObject(this);
            Properties.Settings.Default.Save();
        }

        public static ViewSettings Load()
        {
            ViewSettings settings;
            try
            {
                settings = JsonConvert.DeserializeObject<ViewSettings>(Properties.Settings.Default.ViewSettings) ?? new ViewSettings();
            }
            catch
            {
                settings = new ViewSettings();
            }
            return settings;
        }
    }
}
