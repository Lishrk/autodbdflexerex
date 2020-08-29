using System;
using System.Windows.Input;

namespace AutoDbdFlexerEx.ViewModel
{
    public class Command : ICommand
    {
        private bool _CanExecute;
        public bool CanExecute
        {
            get
            {
                return _CanExecute;
            }
            set
            {
                _CanExecute = value;
                CanExecuteChanged?.Invoke(this, new EventArgs());
            }
        }
        public Action<object> Execute;
        public event EventHandler CanExecuteChanged;
        bool ICommand.CanExecute(object parameter) => CanExecute;
        void ICommand.Execute(object parameter) => Execute?.Invoke(parameter);
    }
}
