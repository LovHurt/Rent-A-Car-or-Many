using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.Identity.Client;

namespace DataAccess.Concrete.EntityFramework
{
    public class CarTableContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectModels;Database=Carss;Trusted_Connection=true");

            public DbSet<Car> Car { get; set; }
            public DbSet<Brand> Brand { get; set; }
            public DbSet<Color> Color { get; set; }
        }
    }
}
