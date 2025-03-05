
using APImaui;
using ENT;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UImaui.ViewModels
{
    public class PersonaConNombreDepartamento : Persona
    {

        #region Atributos
        private string nombreDepartamento;
        #endregion


        #region Propiedades

        /// <summary>
        /// Nombre del departamento al que pertenece la persona
        /// </summary>
        public string NombreDepartamento
        {
            get { return AccionesMaui.NombreDepartamentoPorIDMaui(Id).Result; }
        }

        #endregion

        #region Constructores

        public PersonaConNombreDepartamento()
        {
            // Suponiendo que BL.ListadosBL.obtenerNombreDepartamentoBL es un método que retorna el nombre del departamento
            nombreDepartamento = AccionesMaui.NombreDepartamentoPorIDMaui(Id).Result;
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="persona">Instancia de la persona</param>
        /// <param name="nombreDepartamento">Nombre del departamento asociado</param>
        public PersonaConNombreDepartamento(Persona persona) {

            this.Id=persona.Id;
            this.Nombre=persona.Nombre;
            this.Apellido=persona.Apellido;
            this.Direccion=persona.Direccion;
            this.FechaNac=persona.FechaNac;
            this.Foto=persona.Foto;
            this.Telefono=persona.Telefono;
            this.IdDepartamento=persona.IdDepartamento;


            // Suponiendo que BL.ListadosBL.obtenerNombreDepartamentoBL es un método que retorna el nombre del departamento
            nombreDepartamento = AccionesMaui.NombreDepartamentoPorIDMaui(Id).Result;


        }
        #endregion

    }


}