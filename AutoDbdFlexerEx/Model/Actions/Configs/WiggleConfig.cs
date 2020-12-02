using System.ComponentModel;
using System.Windows.Forms;

namespace AutoDbdFlexerEx.Model.Actions.Configs
{
    public class WiggleConfig : ActionConfig
    {
        private Keys _wiggleRight = Keys.D;
        private Keys _wiggleLeft = Keys.A;

        [Description("Клавиша вигглинга вправо в игре")]
        public Keys WiggleRight
        {
            get
            {
                return _wiggleRight;
            }
            set
            {
                _wiggleRight = value;
                OnPropertyChanged();
            }
        }
        [Description("Клавиша вигглинга влево в игре")]
        public Keys WiggleLeft
        {
            get
            {
                return _wiggleLeft;
            }
            set
            {
                _wiggleLeft = value;
                OnPropertyChanged();
            }
        }

        public WiggleConfig()
        {
            Name = "Вырывание из рук маньяка (wiggle)";
        }
    }
}