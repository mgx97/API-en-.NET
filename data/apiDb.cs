using API.models;
using Microsoft.EntityFrameworkCore;

namespace API.data
{
    public class apiDb : DbContext
    {
        public apiDb(DbContextOptions<apiDb> options): base(options)
        {
        }

        public DbSet <Persona> Persona => Set<Persona> ();
        public DbSet<Ciudad> Ciudades => Set<Ciudad>();
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Cuenta> Cuentas => Set<Cuenta>();
    }
}
