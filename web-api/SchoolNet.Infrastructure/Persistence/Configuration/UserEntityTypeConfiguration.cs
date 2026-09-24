using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolNet.Domain.Entities;
namespace SchoolNet.Infrastructure.Persistence.Configuration
{
    public sealed class UserEntityTypeConfiguration: BaseEntityTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
          
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property( x => x.LastName).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Role).IsRequired();
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.DateOfBirth).IsRequired();
            builder.Property(x => x.PasswordHash).IsRequired();
        }
    }
}
