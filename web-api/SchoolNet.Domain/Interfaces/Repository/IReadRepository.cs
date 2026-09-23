using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Entities.BaseEntitie;
using SchoolNet.Domain.Entities.Pattern_Repository;
namespace SchoolNet.Domain.Interfaces.Repository
{
    public interface IReadRepository<TEntity> where TEntity : AbstractEntity
    {
        Task<TEntity?> GetEntityById(int id,CancellationToken cancellationToken = default);
        IQueryable<TEntity> Query();
    }
}
