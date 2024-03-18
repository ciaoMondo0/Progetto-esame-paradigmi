using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progetto_paradigmi.Progetto.Models.Entities;
using Progetto_paradigmi.Progetto.Models.Configurations;

namespace Progetto_paradigmi.Progetto.Models.Context
{
    public class MyDbContext : DbContext
    {

        public MyDbContext() : base()
        {

        }

        public MyDbContext(DbContextOptions<MyDbContext> config) : base(config)
        {

        }

        public DbSet<DistributionList> DistributionList { get; set; }
        public DbSet<Utenti> User { get; set; }

        public DbSet<RecipientsList> RecipientsList { get; set; }

        public DbSet<Recipients> Recipients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
              
               .UseSqlServer("data source=(LocalDb)\\MSSQLLocalDB;Initial catalog=paradigmi;User Id=paradigmi;Password=paradigmi;TrustServerCertificate=True");

            }
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
