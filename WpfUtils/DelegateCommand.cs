using System;
using System.Windows.Input;

namespace WpfUtils
{
    internal class DelegateCommand : ICommand
    {

        private readonly Action<object> m_ExecuteAction;
        private readonly Func<bool> m_CanExecuteAction;


        public DelegateCommand(Action<Object> executeAction, Func<bool> canExecuteAction = null)
        {
            m_ExecuteAction = executeAction;
            if (canExecuteAction == null)
            {
                canExecuteAction = () => true;
            }
            m_CanExecuteAction = canExecuteAction;
        }

        public bool CanExecute(object parameter)
        {
            return m_CanExecuteAction();
        }

        public void Execute(object parameter)
        {
            m_ExecuteAction(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}