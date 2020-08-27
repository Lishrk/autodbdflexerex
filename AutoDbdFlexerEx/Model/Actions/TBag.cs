using System.Threading;
using System.Threading.Tasks;

namespace AutoDbdFlexerEx.Model.Actions
{
    public class TBag : FlexAction
    {
        public override string Name => "T-Bag";
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

        private protected override async Task DoAction(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await WinAPIHelper.PressKey(System.Windows.Forms.Keys.LControlKey, Press);
                await Task.Delay(Cooldown);
            }
        }
    }
}
