using System;
using System.Windows.Input;

namespace WpfUtils
{
    public abstract class CommandBase : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return CanExecuteImpl(parameter);
        }

        protected abstract bool CanExecuteImpl(object parameter);

        public void Execute(object parameter)
        {
            ExecuteImpl(parameter);
        }

        protected abstract void ExecuteImpl(object parameter);

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
    }
}
