using ENT;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TestApiMaui.Models.Services;

namespace TestApiMaui.ViewModels
{
    internal class ListPersonasVM
    {

        //
        private List<Persona> personas;

        //atributo para la persona seleccionada
        private Persona personaSeleccionada;

        //property changed
        public event PropertyChangedEventHandler? PropertyChanged;

        //
        public List<Persona> Personas
        {
            get { return personas; }
        }

        //cambiara la persona seleccionada y notificara el cambio
        public Persona PersonaSeleccionada
        {
            get
            {
                return personaSeleccionada;
            }

            set
            {
                if (personaSeleccionada != value)
                {
                    personaSeleccionada = value;
                    NotifyPropertyChanged();
                }
            }
        }



        /// COMMANDS


        public ICommand AnadirCommand { get; private set; }
        public ICommand EditarCommand { get; private set; }
        public ICommand DetallesCommand { get; private set; }
        public ICommand BorrarCommand { get; private set; }






        //propiedad que activara los botones de editar y borrar al seleccionar una persona
        public bool EsSeleccionada
        {

            get
            {
                //devuelvo la comprobacion de que sea null o no
                return personaSeleccionada != null;
            }

        }




        //
        public ListPersonasVM()
        {
            try
            {
                rellenaListado();

                DetallesCommand = new Command<Persona>(async (personaSeleccionada) => await IrADetalles());
            }
            catch (Exception e)
            {
                //todo error
            }
        }

        public async void rellenaListado()
        {
            personas= await Servicios.ListadoPersonasMaui();
        }




        /// <summary>
        /// funcion que te lleva a los detalles
        /// </summary>
        /// <returns></returns>
        private async Task IrADetalles()
        {
            if (PersonaSeleccionada != null)
            {
                await Shell.Current.GoToAsync($"MainPage.detallesPersona?personaId={PersonaSeleccionada.Id}");
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
