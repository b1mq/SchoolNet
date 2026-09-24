using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolNet.Domain.Entities;

namespace SchoolNet.Infrastructure.Persistence.Configuration
{
    public sealed class SchoolClassEntityTypeConfiguration : BaseEntityTypeConfiguration<SchoolClass>
    {
        public override void Configure(EntityTypeBuilder<SchoolClass> builder)
        {
           
            
            base.Configure(builder);
           
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.SchoolYear)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.isDeleted)
                .IsRequired();

            
            builder.HasMany(x => x.Students)
                .WithOne(u => u.Class)
                .HasForeignKey(u => u.ClassId)
                .OnDelete(DeleteBehavior.Restrict); 

           
            builder.Navigation(x => x.Students)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            
            builder.HasMany(x => x.ClassSubjects)
                .WithOne() 
                .HasForeignKey(cs => cs.ClassId)
                .OnDelete(DeleteBehavior.Cascade); 

            builder.Navigation(x => x.ClassSubjects)
                .UsePropertyAccessMode(PropertyAccessMode.Field);

         
           
        }
    }
}
