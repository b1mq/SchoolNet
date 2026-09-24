using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Interfaces.Repository.CommonRepositories;
using SchoolNet.Infrastructure.Persistence;

namespace SchoolNet.Infrastructure.Repositories.CommonRepositories
{
    public  class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
