using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace YAN.Demo.BindToSetting.Core
{
    public class ActionCommand : ICommand
    {
        private Action<object> ExecuteAction;

        public ActionCommand(Action<object> ExecuteAction)
        {
            this.ExecuteAction = ExecuteAction;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => ExecuteAction(parameter);
    }
}
