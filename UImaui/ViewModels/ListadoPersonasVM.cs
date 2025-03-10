﻿
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
    public class ListadoPersonasVM : INotifyPropertyChanged
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
            get {
                return personaSeleccionada;
            }

            set {
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
        public ListadoPersonasVM()
        {
            try
            {
                rellenaListado();
                
                /**
                string fotoPrueba= "https://pngmax.com/_next/image?url=https%3A%2F%2Fpng-max.s3.ap-south-1.amazonaws.com%2Flow%2F936505e8-677a-4a6a-af4e-e4a8c0f31dc9.png&w=1200&q=75";
                personas= new List<Persona>
                {
                    new Persona(1,"nombreA","apellidoA",DateTime.Now,"dirA",fotoPrueba,"+34111111111",1),
                    new Persona(2, "Pedro", "Martínez", DateTime.Now, "Avenida Luna 45", fotoPrueba, "+34222222222", 1),
                    new Persona(3, "María", "López", DateTime.Now, "Plaza Estrella 7", fotoPrueba, "+34333333333", 1),
                    new Persona(4, "Juan", "Rodríguez", DateTime.Now, "Calle Río 89", fotoPrueba, "+34444444444", 1),
                    new Persona(5, "Sofía", "Pérez", DateTime.Now, "Paseo Bosque 12", fotoPrueba, "+34555555555", 1),
                    new Persona(6, "Carlos", "Sánchez", DateTime.Now, "Avenida Mar 34", fotoPrueba, "+34666666666", 1),
                    new Persona(7, "Lucía", "Gómez", DateTime.Now, "Calle Flor 56", fotoPrueba, "+34777777777", 1),
                    new Persona(8, "Diego", "Fernández", DateTime.Now, "Plaza Mayor 78", fotoPrueba, "+34888888888", 1),
                    new Persona(9, "Elena", "Díaz", DateTime.Now, "Camino Verde 90", fotoPrueba, "+34999999999", 1),
                    new Persona(10, "Miguel", "Ruiz", DateTime.Now, "Calle Paz 11", fotoPrueba, "+34101010101", 1)
                };
                */

                DetallesCommand = new Command<Persona>(async (personaSeleccionada) => await IrADetalles());
            }
            catch (Exception e)
            {
                //todo error
            }
        }

        public async void rellenaListado()
        {
            personas = await AccionesMaui.ListadoPersonasMaui();
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
