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
    public sealed  class ClassSubjectRepository:Repository<ClassSubject>,IClassSubjectRepository
    {
        private readonly AppDbContext _context;
        public ClassSubjectRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IReadOnlyCollection<ClassSubject>> GetByClassIdAsync(int classid, CancellationToken cancellationToken = default)
        {
            return await _context.ClassSubjects.Where(x => x.ClassId == classid && !x.isDeleted).ToListAsync(cancellationToken);
        }
        public async Task<IReadOnlyCollection<ClassSubject>> GetBySubjectIdAsync(int subjectid, CancellationToken cancellationToken = default)
        {
            return await _context.ClassSubjects.Where(x => x.SubjectId == subjectid && !x.isDeleted).ToListAsync(cancellationToken);
        }
    }
}
