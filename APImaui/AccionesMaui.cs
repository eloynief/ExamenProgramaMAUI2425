using ENT;
using Newtonsoft.Json;
using UIasp.Controllers.API;

namespace APImaui
{
    //clase con las acciones de 
    public class AccionesMaui
    {
        ApiController api;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async List<Persona> ListadoPersonasMaui()
        {
            string cadenaUrl = EnlaceMaui.enlace;

            //enlace de la uri
            Uri uri = new Uri($"{cadenaUrl}personas");

            List<Persona> listadoPersonas = new List<Persona>();
            
            HttpClient mihttpClient;
            HttpResponseMessage miCodigoRespuesta;
            string textoJsonRespuesta;

            //cliente Http
            mihttpClient = new HttpClient();

            try
            {
                miCodigoRespuesta=await mihttpClient.GetAsync(uri);

                //si obtiene correctamente el HTTP
                if (miCodigoRespuesta.IsSuccessStatusCode)
                {

                    textoJsonRespuesta=await mihttpClient.GetStringAsync(uri);

                    mihttpClient.Dispose();

                    //JsonConvert necesita using Newtonsoft.Json;

                    //Es el paquete Nuget de Newtonsoft

                    listadoPersonas = JsonConvert.DeserializeObject<List<Persona>>(textoJsonRespuesta);


                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("No se pudo obtener el HTTP del servidor");
                throw ex;

            }

            return listadoPersonas;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void AnadirPersonaMaui(Persona persona)
        {

            api.Post(persona);

        }





    }
}
