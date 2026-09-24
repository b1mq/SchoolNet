using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Entities.BaseEntitie;

namespace SchoolNet.Domain.Interfaces.Repository.CommonRepositories
{
    public interface IWriteRepository<TEntity> where TEntity : AbstractEntity
    {
        void Add(TEntity entity,CancellationToken cancellationToken = default);
        void Update(TEntity entity);
        void Delete(TEntity entity);

    }
}
