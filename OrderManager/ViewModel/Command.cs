using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OrderManager.ViewModel
{
    public class Command : ICommand
    {
        public Command(Action<object> action)
        {
            ParameterizedAction = action;
        }
        
        public Predicate<object> CanExecuteDelegate { get; set; }
        public Action<object> ParameterizedAction { get; set; }
        //public Action ExecuteDelegate { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (CanExecuteDelegate != null)
            {
                return CanExecuteDelegate(parameter);
            }

            return true;
        }

        public void Execute(object parameter)
        {
            if (ParameterizedAction != null)
            {
                ParameterizedAction(parameter);
            }
        }
    }
}
