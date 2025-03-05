
using APImaui;
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
    [QueryProperty(nameof(personaId), "personaId")]
    class EditarPersonaVM : INotifyPropertyChanged
    {

        PersonaConNombreDepartamento personaSeleccionada;

        int personaId;

        public event PropertyChangedEventHandler? PropertyChanged;


        //obtengo la persona
        public PersonaConNombreDepartamento PersonaSeleccionada
        {
            get
            {
                return personaSeleccionada;
            }
            set
            {
                personaSeleccionada = value;
                NotifyPropertyChanged();

            }
        }



        public int PersonaId
        {
            get
            {
                return personaId;
            }
            set {
                personaId = value;
                NotifyPropertyChanged();
            }

        }





        public ICommand SubmitCommand { private set; get; }
        public ICommand CancelCommand { private set; get; }

        public EditarPersonaVM()
        {
            PersonaSeleccionada=new PersonaConNombreDepartamento(AccionesMaui.PersonaPorIDMaui(PersonaId).Result);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("personaId"))
            {
                int id = int.Parse(query["personaId"].ToString());
                PersonaSeleccionada = new PersonaConNombreDepartamento(AccionesMaui.PersonaPorIDMaui(PersonaId).Result); ;
            }
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
