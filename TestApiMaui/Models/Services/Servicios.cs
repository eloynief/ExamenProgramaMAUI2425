using ENT;

namespace TestApiMaui.Models.Services
{
    public class Servicios
    {


        public static string cadenaUrl = "https://localhost:5174/api/";


        public static async Task<List<Persona>> ListadoPersonasMaui()
        {

            Uri uri = new Uri($"{cadenaUrl}personas");

            List<Persona> listadoPersonas = new List<Persona>();
            HttpResponseMessage miCodigoRespuesta;
            string textoJsonRespuesta;
            HttpClient httpClient=new HttpClient();

            try
            {
                miCodigoRespuesta = await httpClient.GetAsync(uri);



                if (miCodigoRespuesta.IsSuccessStatusCode)
                {
                    textoJsonRespuesta = await miCodigoRespuesta.Content.ReadAsStringAsync();
                    httpClient.Dispose();
                    //listadoPersonas = JsonConvert.DeserializeObject<List<Persona>>(textoJsonRespuesta);
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("No se pudo obtener el HTTP del servidor: " + ex.Message);


            }


            return listadoPersonas;
        }








    }
}
