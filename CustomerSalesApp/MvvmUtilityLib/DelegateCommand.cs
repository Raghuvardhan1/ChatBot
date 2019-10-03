using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmUtilityLib
{
    public class DelegateCommand : ICommand
    {
        private Action<object> _executeMethodAddress;
        private Func<object, bool> _canExecuteMethodAddress;


        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<object> executeMethodAddress, Func<object, bool> canExecuteMethodAddress)
        {
            this._executeMethodAddress = executeMethodAddress;
            this._canExecuteMethodAddress = canExecuteMethodAddress;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteMethodAddress.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            _executeMethodAddress.Invoke(parameter);
        }
    }
}
