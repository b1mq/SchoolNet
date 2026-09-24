using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SchoolNet.Domain.Entities.Spec;
using SchoolNet.Domain.Interfaces.Repository;
using SchoolNet.Infrastructure.Persistence;
using SchoolNet.Infrastructure.Repositories.CommonRepositories;

namespace SchoolNet.Infrastructure.Repositories
{
    public sealed class GradeRepository:Repository<Grade>,IGradeRepository
    {
        private readonly AppDbContext _context;
        public GradeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IReadOnlyCollection<Grade>> GetByStudentIdAsync(int studentId, CancellationToken cancellation = default)
        {
            return await _context.Grades.Where(x => x.StudentId == studentId && !x.isDeleted).ToListAsync(cancellation);
        }
        public async Task<IReadOnlyCollection<Grade>> GetByClassSubjectIdAsync(int classsubjectId, CancellationToken cancellation = default)
        {
            return await _context.Grades.Where(x => x.ClassSubjectId == classsubjectId && !x.isDeleted).ToListAsync(cancellation);
        }
    }
}
