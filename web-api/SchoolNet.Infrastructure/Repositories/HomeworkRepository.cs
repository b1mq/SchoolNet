using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SchoolNet.Domain.Entities;
using SchoolNet.Domain.Entities.Spec;
using SchoolNet.Domain.Interfaces.Repository;
using SchoolNet.Infrastructure.Persistence;
using SchoolNet.Infrastructure.Repositories.CommonRepositories;

namespace SchoolNet.Infrastructure.Repositories
{
    public sealed class HomeworkRepository:Repository<Homework>,IHomeworkRepository
    {
        private readonly AppDbContext _context;
        public HomeworkRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IReadOnlyCollection<Homework>> GetByTitleAsync(string title, CancellationToken cancellationToken = default)
        {
            return await _context.Homeworks.Where(x => x.Title == title && !x.isDeleted).ToListAsync(cancellationToken);
        }
        public async Task<IReadOnlyCollection<Homework>> GetByContentAsync(string content, CancellationToken cancellationToken = default)
        {
            return await _context.Homeworks.Where(x => x.Content == content && !x.isDeleted).ToListAsync(cancellationToken);
        }
        public async Task<IReadOnlyCollection<Homework>> GetByClassSubjectId(int classsubjectId, CancellationToken cancellationToken = default)
        {
            return await _context.Homeworks.Where(x => x.ClassSubjectId == classsubjectId && !x.isDeleted).ToListAsync(cancellationToken);
        }
        public async Task<IReadOnlyCollection<Homework>> GetByTeacherId(int teacherId, CancellationToken cancellationToken = default)
        {
            return await _context.Homeworks.Where(x => x.TeacherId == teacherId && !x.isDeleted).ToListAsync(cancellationToken);
        }
        public async Task<IReadOnlyCollection<Homework>> GetByDueDate(DateTime date, CancellationToken cancellationToken = default)
        {
            return await _context.Homeworks.Where(x => x.DueDate == date && !x.isDeleted).ToListAsync(cancellationToken);
        }
    }
}
