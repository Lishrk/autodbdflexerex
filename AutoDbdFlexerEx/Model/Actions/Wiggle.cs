using System.Threading;
using System.Threading.Tasks;

namespace AutoDbdFlexerEx.Model.Actions
{
    public class Wiggle : FlexAction
    {
        public override string Name => "Вырывание из рук маньяка (wiggle)";

        private protected override async Task DoAction(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await WinAPIHelper.PressKey(System.Windows.Forms.Keys.A, 50);
                await Task.Delay(50);
                await WinAPIHelper.PressKey(System.Windows.Forms.Keys.D, 50);
            }
        }
    }
}
