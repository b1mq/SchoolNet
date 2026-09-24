using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolNet.Domain.Entities;
namespace SchoolNet.Infrastructure.Persistence.Configuration
{
    public sealed class UserEntityTypeConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property( x => x.LastName).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Role).IsRequired();
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.DateOfBirth).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();
            builder.Property(x => x.PasswordHash).IsRequired();
        }
    }
}
