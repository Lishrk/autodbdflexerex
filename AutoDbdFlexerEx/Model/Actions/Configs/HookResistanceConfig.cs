using System.ComponentModel;
using System.Windows.Forms;

namespace AutoDbdFlexerEx.Model.Actions.Configs
{
    public class HookResistanceConfig : ActionConfig
    {
        private Keys _hookResistanceKey;

        [Description("Клавиша сопротивления на крюке в игре")]
        public Keys HookResistanceKey
        {
            get
            {
                return _hookResistanceKey;
            }
            set
            {
                _hookResistanceKey = value;
                OnPropertyChanged();
            }
        }

        public HookResistanceConfig()
        {
            Name = "Сопротивление на крюке";
            HookResistanceKey = Keys.Space;
        }
    }
}
