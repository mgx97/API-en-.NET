using API.data;
using API.models;
using Microsoft.AspNetCore.Mvc;

namespace API.controller
{
    public class UsuarioController
    {
        private readonly apiDb _dbContext;

        public UsuarioController(apiDb dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            _dbContext.SaveChanges();

            return Ok();
        }

        private IActionResult Ok()
        {
            throw new NotImplementedException();
        }

        private IActionResult Ok(List<Usuario> usuarios)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{idUsuario:int}")]
        public IActionResult Get(int idUsuario)
        {
            Usuario usuario = _dbContext.Usuarios.Find(idUsuario);

            if (usuario is null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        private IActionResult NotFound()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_dbContext.Usuarios.ToList());
        }

        [HttpPut("{idUsuario:int}")]
        public IActionResult Put(int idUsuario, [FromBody] Usuario usuario)
        {
            Usuario usuarioActual = _dbContext.Usuarios.Find(idUsuario);

            if (usuarioActual is null)
            {
                return NotFound();
            }

            usuarioActual.IdPersona = usuario.IdPersona;
            usuarioActual.NombreUsuario = usuario.NombreUsuario;
            usuarioActual.Contraseña = usuario.Contraseña;
            usuarioActual.Nivel = usuario.Nivel;
            usuarioActual.Estado = usuario.Estado;

            _dbContext.SaveChanges();

            return Ok(usuarioActual);
        }

        private IActionResult Ok(Usuario usuarioActual)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{idUsuario:int}")]
        public IActionResult Delete(int idUsuario)
        {
            Usuario usuario = _dbContext.Usuarios.Find(idUsuario);

            if (usuario is null)
            {
                return NotFound();
            }

            _dbContext.Usuarios.Remove(usuario);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}

