using Microsoft.EntityFrameworkCore;
using final.Models;

namespace final.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Client> client { get; set; }
        public DbSet<SolarProject> solarProject { get; set; }
        
    }
}