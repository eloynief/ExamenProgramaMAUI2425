using BL;
using ENT;
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
    class CrearPersonaVM : INotifyPropertyChanged
    {

        Persona personaCrear;


        public event PropertyChangedEventHandler? PropertyChanged;



        public Persona PersonaCrear
        {
            get
            {
                return personaCrear;
            }
            set
            {
                personaCrear = value;
                NotifyPropertyChanged();

            }
        }


        public ICommand SubmitCommand { private set; get; }
        public ICommand CancelCommand { private set; get; }


        public CrearPersonaVM(){

            //SubmitCommand= new Command(AccionesBL.CrearPersonaBL(PersonaCrear));



        }



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
