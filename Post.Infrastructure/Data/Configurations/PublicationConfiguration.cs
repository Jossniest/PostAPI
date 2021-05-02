using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Post.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Infrastructure.Data.Configurations
{
    class PublicationConfiguration : IEntityTypeConfiguration<Publication>
    {
        public void Configure(EntityTypeBuilder<Publication> entity)
        {
            entity.HasKey(e => e.PublicationId);
            entity.Property(e => e.PublicationId).UseIdentityColumn(1, 1);

            entity.Property(e => e.Date).HasDefaultValue(DateTime.Now).HasColumnType("datetime");

            entity.Property(e => e.Description)
            .HasMaxLength(1000).IsRequired(true)
            .HasColumnType("varchar");

            entity.Property(e => e.Image)
            .HasMaxLength(1000).IsRequired(true)
            .HasColumnType("varchar");

            entity.HasOne(e => e.User)
            .WithMany(p => p.Publications)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Publication_User");          
        }
    }
}
