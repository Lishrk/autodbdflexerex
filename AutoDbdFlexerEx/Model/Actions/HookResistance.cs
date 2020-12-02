using AutoDbdFlexerEx.Model.Actions.Configs;
using System.Threading;
using System.Threading.Tasks;

namespace AutoDbdFlexerEx.Model.Actions
{
    public class HookResistance : FlexAction<HookResistanceConfig>
    {
        protected override async Task DoAction(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await WinAPIHelper.PressKey(Config.HookResistanceKey, 50);
                await Task.Delay(50);
            }
        }
    }
}
