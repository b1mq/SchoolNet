using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SchoolNet.Domain.Entities;
using SchoolNet.Domain.Interfaces.Repository;
using SchoolNet.Domain.Interfaces.Repository.CommonRepositories;
using SchoolNet.Infrastructure.Persistence;
using SchoolNet.Infrastructure.Repositories.CommonRepositories;

namespace SchoolNet.Infrastructure.Repositories
{
    public sealed class SchoolClassRepository:Repository<SchoolClass>,ISchoolClassRepository
    {
        private readonly AppDbContext _context;
        public SchoolClassRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
        public async Task<IReadOnlyCollection<SchoolClass>> GetByYearAsync(string year, CancellationToken cancellationToken = default)
        {
            return await  _context.SchoolClasses.Where(x => x.SchoolYear == year  && !x.isDeleted).ToListAsync(cancellationToken);
        }
        public async Task<IReadOnlyCollection<SchoolClass>> GetByYearAndNameAsync(string name, string year, CancellationToken cancellation = default)
        {
            return await _context.SchoolClasses.Where(x => x.Name == name && x.SchoolYear == year && !x.isDeleted).ToListAsync(cancellation);
        }
        public async Task<bool> ExistsByYearAndName(string year, string name, CancellationToken cancellation = default)
        {
            return await _context.SchoolClasses.AnyAsync(x => x.SchoolYear == year && x.Name == name && !x.isDeleted,cancellation);
        }
    }
}
