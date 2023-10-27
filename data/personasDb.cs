using Microsoft.EntityFrameworkCore;
using WebApplication1.models;

namespace WebApplication1.data
{
    public class personasDb : DbContext
    {

        public personasDb(DbContextOptions<personasDb> options) : base(options)
        { 
        
        
        }

        public DbSet<persona> personas => Set<persona>();
    }
}
