using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace AutoDbdFlexerEx.Model
{
    public class ActionConfig : INotifyPropertyChanged
    {
        private Keys _activator;
        private string _name;

        public event PropertyChangedEventHandler PropertyChanged;

        [Description("Переключить макрос")]
        public Keys Activator
        {
            get
            {
                return _activator;
            }
            set
            {
                _activator = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
