using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Progetto_paradigmi.Progetto.Models.Entities;

namespace Progetto_paradigmi.Progetto.Models.Configurations
{
    public class RecipientsListConfiguration : IEntityTypeConfiguration<RecipientsList>
    {
        public void Configure(EntityTypeBuilder<RecipientsList> builder)
        {
            builder.ToTable("RecipientsList");

            builder.HasKey(rl => new { rl.DistributionListId, rl.RecipientId });

            builder.HasOne(rl => rl.DistributionList)
                   .WithMany(d => d.RecipientsLists)
                   .HasForeignKey(rl => rl.DistributionListId)
                   .IsRequired();

            builder.HasOne(rl => rl.Recipients)
                   .WithMany(r => r.RecipientsLists)
                   .HasForeignKey(rl => rl.RecipientId)
                   .IsRequired();

        }
    }
}
