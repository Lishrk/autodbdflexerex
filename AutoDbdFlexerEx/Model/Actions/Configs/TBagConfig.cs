using System.ComponentModel;
using System.Windows.Forms;

namespace AutoDbdFlexerEx.Model.Actions.Configs
{
    public class TBagConfig : ActionConfig
    {
        private Keys _CrouchKey;
        private int _Cooldown;
        private int _Press;

        [Description("Время между нажатиями")]
        public int Cooldown
        {
            get
            {
                return _Cooldown;
            }
            set
            {
                _Cooldown = value;
                OnPropertyChanged();
            }
        }
        [Description("Время нажатия клавиши")]
        public int Press
        {
            get
            {
                return _Press;
            }
            set
            {
                _Press = value;
                OnPropertyChanged();
            }
        }
        [Description("Клавиша приседания в игре")]
        public Keys CrouchKey
        {
            get
            {
                return _CrouchKey;
            }
            set
            {
                _CrouchKey = value;
                OnPropertyChanged();
            }
        }

        public TBagConfig()
        {
            Name = "T-Bag";
            CrouchKey = Keys.LControlKey;
            Cooldown = 50;
            Press = 50;
        }
    }
}
