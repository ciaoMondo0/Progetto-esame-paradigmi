using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Progetto_paradigmi.Progetto.Models.Entities;

namespace Progetto_paradigmi.Progetto.Models.Configurations
{
    public class DistributionListConfiguration : IEntityTypeConfiguration<DistributionList>
    {
        public void Configure(EntityTypeBuilder<DistributionList> builder)
        {
            builder.ToTable("DistributionList");
            builder.HasKey(x => x.Id);
            
            builder.HasOne(x => x.Owner)
                   .WithMany()
                   .HasForeignKey(x => x.OwnerId)
                   .IsRequired();



        }
    }
}
