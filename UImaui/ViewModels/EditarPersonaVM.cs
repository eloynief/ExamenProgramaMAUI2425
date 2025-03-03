using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UImaui.ViewModels
{
    class EditarPersonaVM : INotifyPropertyChanged
    {

        PersonaConNombreDepartamento personaEditar;


        public event PropertyChangedEventHandler? PropertyChanged;



        public PersonaConNombreDepartamento PersonaEditar
        {
            get
            {
                return personaEditar;
            }
            set
            {
                personaEditar = value;
                NotifyPropertyChanged();

            }
        }

        public ICommand SubmitCommand { private set; get; }
        public ICommand CancelCommand { private set; get; }




        /// <summary>
        /// Notifica cambios en las propiedades para actualizar la UI
        /// </summary>
        /// <param name="propertyName">Nombre de la propiedad que cambió</param>
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
