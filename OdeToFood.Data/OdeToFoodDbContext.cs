using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeTooFood.Data
{
    public class OdeToFoodDbContext : DbContext 
    {
        public IConfiguration Configuration { get; }

        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options) : base(options)
        {

        }

        public OdeToFoodDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("OdeToFoodDb"));
            }
        }


        public DbSet<Restaurant> Restaurants { get; set;}
    }
}
