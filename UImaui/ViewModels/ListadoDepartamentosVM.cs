
using APImaui;
using ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UImaui.ViewModels
{
    class ListadoDepartamentosVM :INotifyPropertyChanged
    {
        private List<Departamento> departamentos;

        //atributo para la persona seleccionada
        private Departamento departamentoSeleccionado;


        public List<Departamento> Departamentos
        {
            get { return AccionesMaui.ListadoDepartamentosMaui().Result; }
        }


        //property changed
        public event PropertyChangedEventHandler? PropertyChanged;



        //cambiara la persona seleccionada y notificara el cambio
        public Departamento DepartamentoSeleccionado
        {
            get
            {
                return departamentoSeleccionado;
            }

            set
            {
                if (departamentoSeleccionado != value)
                {
                    departamentoSeleccionado = value;
                    NotifyPropertyChanged();
                }
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
