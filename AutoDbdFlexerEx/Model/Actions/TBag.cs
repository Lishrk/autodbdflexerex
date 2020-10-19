using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoDbdFlexerEx.Model.Actions
{
    public class TBag : FlexAction
    {
        private Keys _KeyToPress = Keys.LControlKey;
        private int _Cooldown;
        private int _Press;
        public int Cooldown
        {
            get
            {
                return _Cooldown;
            }
            set
            {
                _Cooldown = value;
                OnPropertyChanged("Cooldown");
            }
        }
        public int Press
        {
            get
            {
                return _Press;
            }
            set
            {
                _Press = value;
                OnPropertyChanged("Press");
            }
        }

        public override string Name => "T-Bag";
        public Keys KeyToPress
        {
            get
            {
                return _KeyToPress;
            }
            set
            {
                _KeyToPress = value;
                OnPropertyChanged();
            }
        }

        private protected override async Task DoAction(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await WinAPIHelper.PressKey(KeyToPress, Press);
                await Task.Delay(Cooldown);
            }
        }
    }
}
