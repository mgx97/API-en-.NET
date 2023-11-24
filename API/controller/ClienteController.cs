using API.data;
using API.models;
using Microsoft.AspNetCore.Mvc;

namespace API.controllers
{
    public class ClienteController : Controller
    {
        private readonly apiDb _dbContext;

        public ClienteController(apiDb dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            _dbContext.Clientes.Add(cliente);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Cliente cliente = _dbContext.Clientes.Find(id);

            if (cliente is null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_dbContext.Clientes.ToList());
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] Cliente cliente)
        {
            Cliente clienteActual = _dbContext.Clientes.Find(id);

            if (clienteActual is null)
            {
                return NotFound();
            }

            clienteActual.IdPersona = cliente.IdPersona;
            clienteActual.Estado = cliente.Estado;
            clienteActual.Calificacion = cliente.Calificacion;
            clienteActual.FechaIngreso = cliente.FechaIngreso;


            _dbContext.SaveChanges();

            return Ok(clienteActual);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Cliente cliente = _dbContext.Clientes.Find(id);

            if (cliente is null)
            {
                return NotFound();
            }

            _dbContext.Clientes.Remove(cliente);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}