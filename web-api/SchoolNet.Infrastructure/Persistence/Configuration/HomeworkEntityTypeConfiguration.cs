using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolNet.Domain.Entities;
using SchoolNet.Domain.Entities.Spec;

namespace SchoolNet.Infrastructure.Persistence.Configuration
{
    public sealed  class HomeworkEntityTypeConfiguration:BaseEntityTypeConfiguration<Homework>
    {
        public override void Configure(EntityTypeBuilder<Homework> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Content).IsRequired().HasMaxLength(500);
            builder.Property(x => x.ClassSubjectId)
                .IsRequired();

            builder.Property(x => x.TeacherId)
                .IsRequired();

            builder.Property(x => x.DueDate)
                .IsRequired();

            builder.Property(x => x.isDeleted)
                .IsRequired();
            builder.HasOne<ClassSubject>()
                .WithMany()
                .HasForeignKey(x => x.ClassSubjectId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
