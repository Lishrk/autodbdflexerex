using AutoDbdFlexerEx.Model.Actions.Configs;
using System.Threading;
using System.Threading.Tasks;

namespace AutoDbdFlexerEx.Model.Actions
{
    public class TBag : FlexAction<TBagConfig>
    {
        protected override async Task DoAction(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await WinAPIHelper.PressKey(Config.CrouchKey, Config.Press);
                await Task.Delay(Config.Cooldown);
            }
        }
    }
}
