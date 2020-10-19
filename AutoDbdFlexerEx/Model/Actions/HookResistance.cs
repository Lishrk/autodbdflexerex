using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoDbdFlexerEx.Model.Actions
{
    public class HookResistance : FlexAction
    {
        private Keys _KeyToPress = Keys.Space;

        public override string Name => "Сопротивление на крюке";
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
                await WinAPIHelper.PressKey(KeyToPress, 50);
                await Task.Delay(50);
            }
        }
    }
}
