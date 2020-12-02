using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace AutoDbdFlexerEx.Model
{
    public abstract class FlexAction<TConfig> : INotifyPropertyChanged, IFlexAction where TConfig : ActionConfig, new()
    {
        private CancellationTokenSource cancellationTokenSource;
        private bool _Active;
        private TConfig _config;

        public event PropertyChangedEventHandler PropertyChanged;

        [JsonIgnore]
        public bool Active
        {
            get
            {
                return _Active;
            }
            set
            {
                _Active = value;
                OnPropertyChanged();
            }
        }
        [JsonProperty]
        public TConfig Config
        {
            get
            {
                return _config;
            }
            set
            {
                _config = value;
                OnPropertyChanged();
            }
        }
        ActionConfig IFlexAction.Config
        {
            get
            {
                return Config;
            }
            set
            {
                Config = (TConfig)value;
            }
        }

        public FlexAction()
        {
            Config = new TConfig();
        }

        public void Start()
        {
            if (!Active)
            {
                cancellationTokenSource = new CancellationTokenSource();
                DoAction(cancellationTokenSource.Token);
                Active = true;
            }
        }
        public void Stop()
        {
            if (Active)
            {
                cancellationTokenSource.Cancel();
                Active = false;
            }
        }
        public void Toggle()
        {
            if (!Active)
            {
                Start();
            }
            else
            {
                Stop();
            }
        }
        protected abstract Task DoAction(CancellationToken cancellationToken);
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
