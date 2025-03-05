using ENT;
using Newtonsoft.Json;
using System.Net;

namespace APImaui
{
    //clase con las acciones de 
    public class AccionesMaui
    {



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static async Task<List<Persona>> ListadoPersonasMaui()
        {
            string cadenaUrl = EnlaceMaui.enlace; // URL base de tu API
            Uri uri = new Uri($"{cadenaUrl}personas");

            List<Persona> listadoPersonas = new List<Persona>();

            using (HttpClient mihttpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage miCodigoRespuesta = await mihttpClient.GetAsync(uri);

                    if (miCodigoRespuesta.IsSuccessStatusCode)
                    {
                        string textoJsonRespuesta = await miCodigoRespuesta.Content.ReadAsStringAsync();
                        listadoPersonas = JsonConvert.DeserializeObject<List<Persona>>(textoJsonRespuesta);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No se pudo obtener el HTTP del servidor: " + ex.Message);
                }
            }

            return listadoPersonas;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<HttpStatusCode> InsertaPersonaDAL(Persona persona)
        {

            HttpClient mihttpClient = new HttpClient();

            string datos;

            HttpContent contenido;

            string cadenaUrl = EnlaceMaui.enlace;

            Uri uri = new Uri($"{cadenaUrl}Personas");

            //Usaremos el Status de la respuesta para comprobar si ha borrado

            HttpResponseMessage miRespuesta = new HttpResponseMessage();

            try

            {

                datos = JsonConvert.SerializeObject(persona);

                contenido = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");

                miRespuesta = await mihttpClient.PostAsync(uri, contenido);

            }

            catch (Exception ex)

            {

                throw ex;

            }

            return miRespuesta.StatusCode;
        }











        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static async Task<Persona> PersonaPorIDMaui(int id)
        {
            string cadenaUrl = EnlaceMaui.enlace;

            //enlace de la uri
            Uri uri = new Uri($"{cadenaUrl}personas/{id}");

            List<Persona> listadoPersonas = new List<Persona>();
            Persona persona = new Persona();

            HttpClient mihttpClient;
            HttpResponseMessage miCodigoRespuesta;
            string textoJsonRespuesta;

            //cliente Http
            mihttpClient = new HttpClient();

            try
            {
                miCodigoRespuesta = await mihttpClient.GetAsync(uri);

                //si obtiene correctamente el HTTP
                if (miCodigoRespuesta.IsSuccessStatusCode)
                {

                    textoJsonRespuesta = await mihttpClient.GetStringAsync(uri);

                    mihttpClient.Dispose();

                    //JsonConvert necesita using Newtonsoft.Json;

                    //Es el paquete Nuget de Newtonsoft

                    listadoPersonas = JsonConvert.DeserializeObject<List<Persona>>(textoJsonRespuesta);

                    foreach(Persona p in listadoPersonas)
                    {
                        if (id == p.Id)
                        {
                            persona = p;
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudo obtener el HTTP del servidor");
                throw ex;

            }

            return persona;
        }



        /// <summary>
        /// Obtiene el listado completo de departamentos
        /// </summary>
        /// <returns>Lista de departamentos</returns>
        public static async Task<List<Departamento>> ListadoDepartamentosMaui()
        {
            string cadenaUrl = EnlaceMaui.enlace; // URL base de tu API
            Uri uri = new Uri($"{cadenaUrl}departamentos"); // Endpoint para departamentos

            List<Departamento> listadoDepartamentos = new List<Departamento>();

            using (HttpClient mihttpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage miCodigoRespuesta = await mihttpClient.GetAsync(uri);

                    if (miCodigoRespuesta.IsSuccessStatusCode)
                    {
                        string textoJsonRespuesta = await miCodigoRespuesta.Content.ReadAsStringAsync();
                        listadoDepartamentos = JsonConvert.DeserializeObject<List<Departamento>>(textoJsonRespuesta);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No se pudo obtener el HTTP del servidor: " + ex.Message);
                }
            }

            return listadoDepartamentos;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static async Task<string> NombreDepartamentoPorIDMaui(int id)
        {
            string cadenaUrl = EnlaceMaui.enlace;

            //enlace de la uri
            Uri uri = new Uri($"{cadenaUrl}departamentos");

            List<Departamento> listadoPersonas = new List<Departamento>();
            Departamento persona = new Departamento();

            HttpClient mihttpClient;
            HttpResponseMessage miCodigoRespuesta;
            string textoJsonRespuesta;

            //cliente Http
            mihttpClient = new HttpClient();

            try
            {
                miCodigoRespuesta = await mihttpClient.GetAsync(uri);

                //si obtiene correctamente el HTTP
                if (miCodigoRespuesta.IsSuccessStatusCode)
                {

                    textoJsonRespuesta = await mihttpClient.GetStringAsync(uri);

                    mihttpClient.Dispose();

                    //JsonConvert necesita using Newtonsoft.Json;

                    //Es el paquete Nuget de Newtonsoft

                    listadoPersonas = JsonConvert.DeserializeObject<List<Departamento>>(textoJsonRespuesta);

                    foreach (Departamento p in listadoPersonas)
                    {
                        if (id == p.Id)
                        {
                            persona = p;
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudo obtener el HTTP del servidor");
                throw ex;

            }

            return persona.Nombre;
        }




    }
}
