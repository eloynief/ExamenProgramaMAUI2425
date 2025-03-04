using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UImaui.ViewModels
{
    internal class PaginasVM
    {
        public ICommand IrAPersonasCommand { get; }
        public ICommand IrADeptsCommand { get; }

        public PaginasVM()
        {
            IrAPersonasCommand = new Command(async () => await IrAPersonas());
            IrADeptsCommand = new Command(async () => await IrADepts());
        }

        private async Task IrAPersonas()
        {
            await Shell.Current.GoToAsync("//MainPage.personas");
        }

        private async Task IrADepts()
        {
            await Shell.Current.GoToAsync("//MainPage.departamentos");
        }
    }
}
