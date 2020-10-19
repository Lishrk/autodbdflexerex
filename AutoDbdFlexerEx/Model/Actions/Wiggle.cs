using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoDbdFlexerEx.Model.Actions
{
    public class Wiggle : FlexAction
    {
        private Keys _WiggleRight = Keys.D;
        private Keys _WiggleLeft = Keys.A;

        public override string Name => "Вырывание из рук маньяка (wiggle)";
        public Keys WiggleRight
        {
            get
            {
                return _WiggleRight;
            }
            set
            {
                _WiggleRight = value;
                OnPropertyChanged();
            }
        }
        public Keys WiggleLeft
        {
            get
            {
                return _WiggleLeft;
            }
            set
            {
                _WiggleLeft = value;
                OnPropertyChanged();
            }
        }

        private protected override async Task DoAction(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await WinAPIHelper.PressKey(WiggleLeft, 50);
                await Task.Delay(50);
                await WinAPIHelper.PressKey(WiggleRight, 50);
            }
        }
    }
}
