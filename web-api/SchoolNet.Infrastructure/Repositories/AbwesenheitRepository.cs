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
    public class AbwesenheitRepository:Repository<Abwesenheit>,IAbwesenheitRepository
    {
        private readonly AppDbContext _context;
        public AbwesenheitRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IReadOnlyCollection<Abwesenheit>> GetByStudentIdAsync(int studentId, CancellationToken cancellationToken = default)
        {
            return await _context.Abwesenheits.Where(x => x.StudentId == studentId && !x.isDeleted).ToListAsync(cancellationToken);
        }
        public async Task<IReadOnlyCollection<Abwesenheit>> GetBySheduleIDAsync(int classsheduleId, CancellationToken cancellationToken = default)
        {
            return await _context.Abwesenheits.Where(x => x.ScheduleId == classsheduleId && !x.isDeleted).ToListAsync(cancellationToken);
        }
    }
}
