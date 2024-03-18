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
    public class RecipientsConfiguration : IEntityTypeConfiguration<Recipients>
    {
        public void Configure(EntityTypeBuilder<Recipients> builder)
        {
            builder.ToTable("Recipients");
            builder.HasKey(x => x.Id);



        }
    }
}
