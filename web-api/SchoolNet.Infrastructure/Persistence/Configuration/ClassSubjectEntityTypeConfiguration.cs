using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolNet.Domain.Entities;

namespace SchoolNet.Infrastructure.Persistence.Configuration
{
    public sealed  class ClassSubjectEntityTypeConfiguration:BaseEntityTypeConfiguration<ClassSubject>
    {
        public override void Configure(EntityTypeBuilder<ClassSubject> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.ClassId)
                .IsRequired();

            builder.Property(x => x.SubjectId)
                .IsRequired();

            builder.Property(x => x.isDeleted)
                .IsRequired();
            builder.HasOne(x => x.SClass)
            .WithMany(x => x.ClassSubjects)
            .HasForeignKey(x => x.ClassId)
            .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Subject).WithMany().HasForeignKey(x => x.SubjectId).OnDelete(DeleteBehavior.Cascade);
            builder.HasIndex(x => new { x.ClassId, x.SubjectId })
                .IsUnique();
        }
    }
}
