using Labb2LINQ.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2LINQ.Data
{
    class DBContextLabb2LINQ : DbContext
    {
        public DbSet<Kurs> Kurser { get; set; }
        public DbSet<Student> Studenter { get; set; }
        public DbSet<Ämne> Ämnen { get; set; }
        public DbSet<Lärare> Lärare { get; set; }
        public DbSet<KursÄmne> KursÄmne { get; set; }
        public DbSet<LärareÄmne> LärareÄmnen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer("Data Source = DESKTOP-6TSF82P; Initial Catalog = Labb2LINQ; Integrated Security = True;"));
        }
    }
    
}   
