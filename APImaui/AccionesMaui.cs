using ENT;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace APImaui
{
    public class AccionesMaui
    {
        // HttpClient estático y reutilizable
        private static readonly HttpClient _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(10) // Timeout para evitar esperas largas
        };

        /// <summary>
        /// Obtiene el listado de personas
        /// </summary>
        public static async Task<List<Persona>> ListadoPersonasMaui()
        {
            string cadenaUrl = EnlaceMaui.enlace;
            Uri uri = new Uri($"{cadenaUrl}personas");
            List<Persona> listadoPersonas = new();

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    listadoPersonas = JsonConvert.DeserializeObject<List<Persona>>(jsonResponse) ?? new List<Persona>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener personas: {ex.Message}");
            }

            return listadoPersonas;
        }

        /// <summary>
        /// Inserta una persona en la API
        /// </summary>
        public async Task<HttpStatusCode> InsertaPersonaDAL(Persona persona)
        {
            string cadenaUrl = EnlaceMaui.enlace;
            Uri uri = new Uri($"{cadenaUrl}personas");

            try
            {
                string datos = JsonConvert.SerializeObject(persona);
                using StringContent contenido = new(datos, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(uri, contenido);
                return response.StatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar persona: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene una persona por ID
        /// </summary>
        public static async Task<Persona> PersonaPorIDMaui(int id)
        {
            string cadenaUrl = EnlaceMaui.enlace;
            Uri uri = new Uri($"{cadenaUrl}personas/{id}");
            Persona persona = null;

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    persona = JsonConvert.DeserializeObject<Persona>(jsonResponse);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener persona por ID: {ex.Message}");
            }

            return persona ?? new Persona();
        }

        /// <summary>
        /// Obtiene el listado completo de departamentos
        /// </summary>
        public static async Task<List<Departamento>> ListadoDepartamentosMaui()
        {
            string cadenaUrl = EnlaceMaui.enlace;
            Uri uri = new Uri($"{cadenaUrl}departamentos");
            List<Departamento> listadoDepartamentos = new();

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    listadoDepartamentos = JsonConvert.DeserializeObject<List<Departamento>>(jsonResponse) ?? new List<Departamento>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener departamentos: {ex.Message}");
            }

            return listadoDepartamentos;
        }

        /// <summary>
        /// Obtiene el nombre de un departamento por ID
        /// </summary>
        public static async Task<string> NombreDepartamentoPorIDMaui(int id)
        {
            string cadenaUrl = EnlaceMaui.enlace;
            Uri uri = new Uri($"{cadenaUrl}departamentos/{id}");
            string nombre = string.Empty;

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var departamento = JsonConvert.DeserializeObject<Departamento>(jsonResponse);
                    nombre = departamento?.Nombre ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener nombre del departamento: {ex.Message}");
            }

            return nombre;
        }
    }
}