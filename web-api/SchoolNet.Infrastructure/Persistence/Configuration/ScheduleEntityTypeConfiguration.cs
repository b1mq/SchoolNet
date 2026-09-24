using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolNet.Domain.Entities;

namespace SchoolNet.Infrastructure.Persistence.Configuration
{
    public sealed  class ScheduleEntityTypeConfiguration:BaseEntityTypeConfiguration<Schedule>
    {
        public override void Configure(EntityTypeBuilder<Schedule> builder) => base.Configure(builder);

    }
}
