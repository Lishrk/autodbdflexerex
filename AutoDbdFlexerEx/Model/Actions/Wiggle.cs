using AutoDbdFlexerEx.Model.Actions.Configs;
using System.Threading;
using System.Threading.Tasks;

namespace AutoDbdFlexerEx.Model.Actions
{
    public class Wiggle : FlexAction<WiggleConfig>
    {
        protected override async Task DoAction(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await WinAPIHelper.PressKey(Config.WiggleLeft, 50);
                await Task.Delay(50);
                await WinAPIHelper.PressKey(Config.WiggleLeft, 50);
            }
        }
    }
}
