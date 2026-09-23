using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SchoolNet.Domain.Entities.BaseEntitie;
using SchoolNet.Domain.Interfaces.Repository;
using SchoolNet.Infrastructure.Persistence;

namespace SchoolNet.Infrastructure.Repositories
{
    public class Repository<TEntity>:IRepository<TEntity> where TEntity : AbstractEntity
    {
        protected readonly AppDbContext Context;
        protected readonly DbSet<TEntity> DbSet;
        public Repository(AppDbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();

        }
        public async Task<TEntity?> GetEntityById(int id,CancellationToken cancellationToken = default)
        {
            return await DbSet.FindAsync(new object[] { id }, cancellationToken);
        }
        public IQueryable<TEntity> Query()
        {
            return DbSet;
        }
        public void Add(TEntity entity,CancellationToken cancellationToken = default)
        {
            DbSet.Add(entity);
        }
        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }
        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }
    }
}
