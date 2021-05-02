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
    class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> entity)
        {
            entity.HasKey(e => e.CommentId);
            entity.Property(e => e.CommentId).UseIdentityColumn(1, 1);

            entity.Property(e => e.Date).HasDefaultValue(DateTime.Now).HasColumnType("datetime");

            entity.Property(e => e.Description)
            .HasMaxLength(1000).IsRequired(true)
            .HasColumnType("varchar");

            entity.HasOne(e => e.Publications)
            .WithMany(p => p.Comments)
            .HasForeignKey(e => e.PublicationId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Comment_Publication");

            entity.HasOne(e => e.User)
            .WithMany(p => p.Comments)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Comment_User");
        }
    }
}
