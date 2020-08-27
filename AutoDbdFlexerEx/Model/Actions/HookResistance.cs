using System.Threading;
using System.Threading.Tasks;

namespace AutoDbdFlexerEx.Model.Actions
{
    public class HookResistance : FlexAction
    {
        public override string Name => "Сопротивление на крюке";

        private protected override async Task DoAction(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await WinAPIHelper.PressKey(System.Windows.Forms.Keys.Space, 50);
                await Task.Delay(50);
            }
        }
    }
}
