using API.data;
using API.models;
using Microsoft.AspNetCore.Mvc;

namespace API.controllers
{
    public class CiudadController : Controller
    {
        private readonly apiDb _dbContext;

        public CiudadController(apiDb dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Ciudad ciudad)
        {
            _dbContext.Ciudades.Add(ciudad);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Ciudad ciudad = _dbContext.Ciudades.Find(id);

            if (ciudad is null)
            {
                return NotFound();
            }

            return Ok(ciudad);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_dbContext.Ciudades.ToList());
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] Ciudad ciudad)
        {
            Ciudad ciudadActual = _dbContext.Ciudades.Find(id);

            if (ciudadActual is null)
            {
                return NotFound();
            }

            ciudadActual.NombreCiudad = ciudad.NombreCiudad;
            ciudadActual.Departamento = ciudad.Departamento;
            ciudadActual.CodigoPostal = ciudad.CodigoPostal;

            _dbContext.SaveChanges();

            return Ok(ciudadActual);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            Ciudad ciudad = _dbContext.Ciudades.Find(id);

            if (ciudad is null)
            {
                return NotFound();
            }

            _dbContext.Ciudades.Remove(ciudad);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
