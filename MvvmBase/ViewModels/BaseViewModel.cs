using MvvmBase.Classes;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmBase.ViewModels
{
    public abstract class BaseViewModel : BaseNotify
    {
        List<DelegateCommandBase> _commands;

        public BaseViewModel()
        {
            CommandManager.RequerySuggested += CommandManager_RequerySuggested;
            Loaded();
        }

        public abstract void Loaded();

        private void CommandManager_RequerySuggested(object sender, EventArgs e)
        {
            RaiseCanExecuteChangedOnCommands();
        }

        protected void RaiseCanExecuteChangedOnCommands()
        {
            if (_commands == null)
            {
                var delegateCommands = GetDelegateCommands(this.GetType(), this);
                _commands = delegateCommands.Where(cm => cm != null).ToList();
            }
            if (_commands != null)
                _commands.ForEach(cm => cm.RaiseCanExecuteChanged());

            IEnumerable<DelegateCommandBase> GetDelegateCommands(Type type, object instance)
            {
                return type.GetProperties().Where(p => typeof(DelegateCommandBase).IsAssignableFrom(p.PropertyType)).Select(p => p.GetValue(instance) as DelegateCommandBase);
            }
        }
    }
}
