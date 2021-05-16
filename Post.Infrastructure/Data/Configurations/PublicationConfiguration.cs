using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Post.Core.Entities;
using System;

namespace Post.Infrastructure.Data.Configurations
{
    class PublicationConfiguration : IEntityTypeConfiguration<Publication>
    {
        public void Configure(EntityTypeBuilder<Publication> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).UseIdentityColumn(1, 1);
            entity.Property(e => e.Id).HasColumnName("PublicationId");

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
