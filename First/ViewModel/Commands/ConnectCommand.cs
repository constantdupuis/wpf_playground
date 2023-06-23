using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace First.ViewModel.Commands
{
    public class ConnectCommand : ICommand
    {
        private readonly ConnectWindowViewModel vm;

        public event EventHandler? CanExecuteChanged;

        public ConnectCommand( ConnectWindowViewModel vm) {
            this.vm = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return vm.CanConnect;
        }

        public void Execute(object? parameter)
        {
            var p = parameter;
        }
    }
}
