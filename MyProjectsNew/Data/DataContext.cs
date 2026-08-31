using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MyProjectsNew.Data
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {


        }
        public DbSet<Entities.CustomerName> CustomerName { get; set; }
        public DbSet<Entities.CustomerPersonnelNames> CustomerPersonnelNames { get; set; }
        public DbSet<Entities.Goods> Goods { get; set; }


    }
}
