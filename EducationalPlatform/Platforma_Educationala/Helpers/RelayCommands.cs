using System;
using System.Windows.Input;

namespace Platforma_Educationala.Helpers
{
    class RelayCommand<T> : ICommand
    {
        private Action<T> commandTask;
        private Predicate<T> canExecuteTask;

        public RelayCommand(Action<T> workToDo, Predicate<T> canExecute = null)
        {
            commandTask = workToDo;
            canExecuteTask = canExecute;
        }


        public bool CanExecute(object parameter)
        {
            return canExecuteTask == null || canExecuteTask((T)parameter);
        }

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

        public void Execute(object parameter)
        {
            commandTask((T)parameter);
        }
    }
}
