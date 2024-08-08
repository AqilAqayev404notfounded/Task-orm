using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_orm.Models;

namespace Task_orm.Contex
{
    public class AppDbContex : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Catagory> Catagory { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-Q4SUHALF;Database=Shop11;Trusted_connection=True");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
