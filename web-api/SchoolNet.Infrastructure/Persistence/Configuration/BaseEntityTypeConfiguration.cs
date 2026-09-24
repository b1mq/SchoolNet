using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolNet.Domain.Entities.BaseEntitie;
using SchoolNet.Domain.Interfaces.Common;

namespace SchoolNet.Infrastructure.Persistence.Configuration
{
    public abstract class BaseEntityTypeConfiguration<TEntity>:IEntityTypeConfiguration<TEntity> where TEntity : AbstractEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();
            if(typeof(ISoftDeletable).IsAssignableFrom(typeof(AbstractEntity)))
            {
                builder.Property(x => ((ISoftDeletable)x).isDeleted) 
                    .IsRequired();
            }
        }
    }
}
