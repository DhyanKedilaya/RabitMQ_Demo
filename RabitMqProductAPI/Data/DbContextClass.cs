using Microsoft.EntityFrameworkCore;
using RabitMqProductAPI.Models;


namespace RabitMqProductAPI.Data
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            //defaultconnection is defined in appsetings.json
        }
        public DbSet< Product > Products { get; set; }
    }
}
