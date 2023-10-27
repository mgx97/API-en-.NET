using Microsoft.EntityFrameworkCore;
using WebApplication1.models;

namespace WebApplication1.data
{
    public class ciudadDb : DbContext
    {

        public ciudadDb(DbContextOptions<ciudadDb> options) : base(options)
        {


        }

        public DbSet<ciudad> cuidad => Set<ciudad>();
    }
}
