using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoDbdFlexerEx.Model
{
    public abstract class FlexAction : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Task actionTask;
        private CancellationTokenSource cancellationTokenSource;
        private Keys _Activator;
        private bool _Active;
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
        public Keys Activator
        {
            get
            {
                return _Activator;
            }
            set
            {
                _Activator = value;
                OnPropertyChanged("Activator");
            }
        }
        [JsonIgnore]
        public abstract string Name { get; }

        private protected abstract Task DoAction(CancellationToken cancellationToken);
        private protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void Start()
        {
            if (!Active)
            {
                cancellationTokenSource = new CancellationTokenSource();
                actionTask = DoAction(cancellationTokenSource.Token);
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
    }
}
