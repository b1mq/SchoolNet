using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolNet.Domain.Entities;

namespace SchoolNet.Infrastructure.Persistence.Configuration
{
    public sealed class SubjectEntityTypeConfiguration : BaseEntityTypeConfiguration<Subject>
    {
        public override void Configure(EntityTypeBuilder<Subject> builder)
        {
            
            
            base.Configure(builder);
          
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100);

           
            builder.HasIndex(x => x.Title)
                .IsUnique();

            
            builder.Property(x => x.isDeleted)
                .IsRequired();

           
           
        }
    }
}
