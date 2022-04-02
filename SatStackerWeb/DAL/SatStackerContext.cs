using Microsoft.EntityFrameworkCore;
using SatStackerWeb.Models;

namespace SatStackerWeb.DAL
{
    public class SatStackerContext : DbContext
    {
        private readonly IConfiguration _config;
        public SatStackerContext(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<EntityTransaction> Transactions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("default"));
        }
    }

    
}
