using API.data;
using API.models;
using Microsoft.AspNetCore.Mvc;
        public class CuentaController : Controller
        {
            private readonly apiDb _dbContext;

            public CuentaController(apiDb dbContext)
            {
                _dbContext = dbContext;
            }

            [HttpPost]
            public IActionResult Post([FromBody] Cuenta cuenta)
            {
                _dbContext.Cuentas.Add(cuenta);
                _dbContext.SaveChanges();

                return Ok();
            }

            [HttpGet("{id:int}")]
            public IActionResult Get(int id)
            {
                Cuenta cuenta = _dbContext.Cuentas.Find(id);

                if (cuenta is null)
                {
                    return NotFound();
                }

                return Ok(cuenta);
            }

            [HttpGet]
            public IActionResult GetAll()
            {
                return Ok(_dbContext.Cuentas.ToList());
            }

            [HttpPut("{id:int}")]
            public IActionResult Put(int id, [FromBody] Cuenta cuenta)
            {
                Cuenta cuentaActual = _dbContext.Cuentas.Find(id);

                if (cuentaActual is null)
                {
                    return NotFound();
                }

                cuentaActual.IdCliente = cuenta.IdCliente;
                cuentaActual.NroCuenta = cuenta.NroCuenta;
                cuentaActual.FechaAlta = cuenta.FechaAlta;
                cuentaActual.TipoCuenta = cuenta.TipoCuenta;
                cuentaActual.Estado = cuenta.Estado;
                cuentaActual.Saldo = cuenta.Saldo;
                cuentaActual.NroContrato = cuenta.NroContrato;
                cuentaActual.TipoCuenta = cuentaActual.TipoCuenta;

                _dbContext.SaveChanges();

                return Ok(cuentaActual);
            }

            [HttpDelete("{id:int}")]
            public IActionResult Delete(int id)
            {
                Cuenta cuenta = _dbContext.Cuentas.Find(id);

                if (cuenta is null)
                {
                    return NotFound();
                }

                _dbContext.Cuentas.Remove(cuenta);
                _dbContext.SaveChanges();

                return Ok();
            }
        }
