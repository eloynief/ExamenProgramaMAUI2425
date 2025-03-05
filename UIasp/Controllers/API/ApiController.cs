using BL;
using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//clase de la api
namespace UIasp.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        // GET: api/<ApiController>
        [HttpGet]
        public IEnumerable<Persona> Get()
        {
            List<Persona> list = ListadosBL.ListadoPersonasBL();

            //directamente te devuelve la funcion
            return list;
        }

        // GET api/<ApiController>/5
        [HttpGet("{id}")]
        public Persona Get(int id)
        {
            Persona persona= ListadosBL.ObtenerPersonaPorIdBL(id);

            return persona;
        }

        // POST api/<ApiController>
        [HttpPost]
        public bool Post([FromBody] Persona p)
        {
            bool comp=AccionesBL.CrearPersonaBL(p);

            return comp;
        }

        // PUT api/<ApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Persona p)
        {
            Persona persona = ListadosBL.ObtenerPersonaPorIdBL(id);

            AccionesBL.EditarPersonaBL(p);
        }

        // DELETE api/<ApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            AccionesBL.DeletePersonaBL(id);
        }
    }
}
