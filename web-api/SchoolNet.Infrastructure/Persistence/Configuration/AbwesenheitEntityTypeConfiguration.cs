using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolNet.Domain.Entities;
using SchoolNet.Domain.Entities.Spec;

namespace SchoolNet.Infrastructure.Persistence.Configuration
{
    public sealed class AbwesenheitEntityTypeConfiguration:BaseEntityTypeConfiguration<Abwesenheit>
    {
        public override void Configure(EntityTypeBuilder<Abwesenheit> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.StudentId)
                .IsRequired();

           
            builder.Property(x => x.ScheduleId)
                .IsRequired(false);

            builder.Property(x => x.Date)
                .IsRequired();

            
            builder.Property(x => x.Reason)
                .HasMaxLength(500);

         
            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.isDeleted)
                .IsRequired();

            
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            
            builder.HasOne<Schedule>()
                .WithMany()
                .HasForeignKey(x => x.ScheduleId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
