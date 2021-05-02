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
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => e.UserId);
            entity.Property(e => e.UserId).UseIdentityColumn(1, 1);

            entity.Property(e => e.BirthDate).HasColumnType("datetime").IsRequired();

            entity.Property(e => e.FirstName)
            .HasMaxLength(100).IsRequired(true)
            .HasColumnType("varchar");

            entity.Property(e => e.LastName)
            .HasMaxLength(100).IsRequired(true)
            .HasColumnType("varchar");

            entity.Property(e => e.FullName)
            .HasComputedColumnSql("[FirstName]+ ' ' + [LastName]");

            entity.Property(e => e.PhoneNumber)
            .HasMaxLength(20).IsRequired(true)
            .HasColumnType("varchar");

            entity.Property(e => e.Email)
           .HasMaxLength(100).IsRequired(true)
           .HasColumnType("varchar");
        }
    }
}
