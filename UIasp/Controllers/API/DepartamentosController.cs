﻿using BL;
using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UIasp.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        // GET: api/<DepartamentosController>
        [HttpGet]
        public IEnumerable<Departamento> Get()
        {
            return ListadosBL.ListadoDepartamentosBL();
        }

        // GET api/<DepartamentosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return ListadosBL.ObtenerNombreDepartamentoBL(id);
        }

        // POST api/<DepartamentosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DepartamentosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DepartamentosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
