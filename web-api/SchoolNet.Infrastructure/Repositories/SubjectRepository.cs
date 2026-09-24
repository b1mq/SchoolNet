using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SchoolNet.Domain.Entities;
using SchoolNet.Domain.Interfaces.Repository;
using SchoolNet.Infrastructure.Persistence;
using SchoolNet.Infrastructure.Repositories.CommonRepositories;

namespace SchoolNet.Infrastructure.Repositories
{
    public sealed class SubjectRepository:Repository<Subject>,ISubjectRepository
    {
        private readonly AppDbContext _context;
        public SubjectRepository(AppDbContext context):base(context)
        {
            _context = context;
        }
        public async Task<Subject?> GetSubjectByTitleAsync(string title,CancellationToken cancellationToken =default)
        {
            return await _context.Subjects.FirstOrDefaultAsync(x => x.Title == title && !x.isDeleted,cancellationToken);
        }
    }
}
