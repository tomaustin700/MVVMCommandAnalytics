using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MvvmBase.Classes
{
    public class CustomDelegateCommand<T> : DelegateCommand<T>
    {
        private Action<T> _executeMethod;
        private string _commandName;


        public CustomDelegateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
            : base(executeMethod, canExecuteMethod)
        {
            _executeMethod = executeMethod;
        }

        public CustomDelegateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod, string commandName)
          : base(executeMethod, canExecuteMethod)
        {
            _executeMethod = executeMethod;
            _commandName = commandName;
        }

        public CustomDelegateCommand(Action<T> executeMethod)
           : base(executeMethod)
        {
            _executeMethod = executeMethod;
        }

        public CustomDelegateCommand(Action<T> executeMethod, string commandName)
         : base(executeMethod)
        {
            _executeMethod = executeMethod;
            _commandName = commandName;
        }

        protected override void Execute(object parameter)
        {
            var data = new CommandData() { ExecuteMethodName = _executeMethod.Method.Name };

            Telemetry.SendCommandData(data);

            base.Execute(parameter);
        }
    }

    public class CustomDelegateCommand : DelegateCommand
    {
        private Action _executeMethod;
        private string _commandName;
        public CustomDelegateCommand(Action executeMethod) : base(executeMethod)
        {
            _executeMethod = executeMethod;
        }

        public CustomDelegateCommand(Action executeMethod, string commandName) : base(executeMethod)
        {
            _executeMethod = executeMethod;
            _commandName = commandName;
        }

        public CustomDelegateCommand(Action executeMethod, Func<bool> canExecuteMethod) : base(executeMethod, canExecuteMethod)
        {
            _executeMethod = executeMethod;
        }

        public CustomDelegateCommand(Action executeMethod, Func<bool> canExecuteMethod, string commandName) : base(executeMethod, canExecuteMethod)
        {
            _executeMethod = executeMethod;
            _commandName = commandName;
        }

        protected override void Execute(object parameter)
        {

            var data = new CommandData() { ExecuteMethodName = _executeMethod.Method.Name, CommandName = _commandName };

            Telemetry.SendCommandData(data);

            base.Execute(parameter);
        }
    }
}
