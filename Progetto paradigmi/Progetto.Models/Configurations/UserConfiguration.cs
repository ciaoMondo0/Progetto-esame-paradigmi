using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Progetto_paradigmi.Progetto.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Progetto_paradigmi.Progetto.Models.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Utenti>
    {
        public void Configure(EntityTypeBuilder<Utenti> builder)
        {
            builder.ToTable("Utenti");
            builder.HasKey(x => x.Id);
           


        }
    }
}
