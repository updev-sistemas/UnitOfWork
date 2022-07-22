using Infrastructure.Data.Entities;
using Infrastructure.Data.Mapping.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Mapping
{
    public class UserEntityMapping : IEntityTypeConfiguration<UserEntity>, IMapping
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            _ = builder ?? throw new ArgumentNullException(nameof(builder));

            _ = builder.ToTable("tb_users");
            _ = builder.HasKey(x => x.Id);
            _ = builder.Property(x => x.Id).HasColumnName("id");
            _ = builder.Property(x => x.Email).HasColumnName("email").IsRequired().HasMaxLength(120);
            _ = builder.Property(x => x.UserName).HasColumnName("username").IsRequired().HasMaxLength(60);
            _ = builder.Property(x => x.CreatedAt).HasColumnName("created_at");
            _ = builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");

            _ = builder.HasIndex(x => x.Email).IsUnique();
            _ = builder.HasIndex(x => x.UserName).IsUnique();
        }

        public void Initialize()
        {
        }
    }
}
