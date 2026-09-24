using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolNet.Domain.Entities;
using SchoolNet.Domain.Entities.Spec;

namespace SchoolNet.Infrastructure.Persistence.Configuration
{
    public sealed  class GradeEntityTypeConfiguration:BaseEntityTypeConfiguration<Grade>
    {
        public override void Configure(EntityTypeBuilder<Grade> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Value).IsRequired().HasMaxLength(3);
            builder.Property(x => x.TeacherId).IsRequired();
            builder.Property(x => x.StudentId).IsRequired();
            builder.Property(x => x.Comment)
                .HasMaxLength(500);
            builder.Property(x => x.isDeleted)
                .IsRequired();
            builder.Property(x => x.ClassSubjectId)
                .IsRequired();
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne<ClassSubject>()
                .WithMany()
                .HasForeignKey(x => x.ClassSubjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
