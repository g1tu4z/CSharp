using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp2.Commands
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action<string> _action;
        private readonly Func<bool> _canExcecute;
        public DelegateCommand(Action<string> action, Func<bool> canExcecute= default)
        {
            this._action = action;
            this._canExcecute = canExcecute;
        }

        public bool CanExecute(object param)
        {
            return _canExcecute?.Invoke() ?? true;
        }

        public void Execute(object parameter)
        {
            _action?.Invoke((string)parameter);
        }

        public void DelegateCanExecute()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// 任意の型の引数を1つ受け付けるDelegateCommand
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DelegateCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action<T> _action;
        private readonly Func<T, bool> _canExecute;
        public DelegateCommand(Action<T> action, Func<T, bool> canExecute = default)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke((T)parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            _action?.Invoke((T)parameter);
        }

        public void DelegateCanExecute()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
