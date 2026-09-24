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
    public sealed  class SheduleRepository:Repository<Schedule>,IScheduleRepository
    {
        private readonly AppDbContext _context;
        public SheduleRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IReadOnlyCollection<Schedule>> GetByRoomIdAsync(int roomId, CancellationToken cancellationToken = default)
        {
            return await _context.Schedules.Where(x => x.RoomId == roomId && !x.isDeleted).ToListAsync(cancellationToken);
        }
        public async Task<IReadOnlyCollection<Schedule>> GetByTeacherIdAsync(int teacherId, CancellationToken cancellationToken = default)
        {
            return await _context.Schedules.Where(x => x.TeacherId == teacherId && !x.isDeleted).ToListAsync(cancellationToken);
        }
        public async Task<IReadOnlyCollection<Schedule>> GetByClassSubjectIdAsync(int ClassSubjectId, CancellationToken cancellationToken = default)
        {
            return await _context.Schedules.Where(x => x.ClassSubjectId == ClassSubjectId && !x.isDeleted).ToListAsync(cancellationToken);
        }
        public async Task<IReadOnlyCollection<Schedule>> GetByStartTimeAsync(TimeOnly startTime, CancellationToken cancellationToken = default)
        {
            return await _context.Schedules.Where(x => x.StartTime == startTime && !x.isDeleted).ToListAsync(cancellationToken);
        }
        public async Task<IReadOnlyCollection<Schedule>> GetByEndTimeAsync(TimeOnly endTime, CancellationToken cancellationToken = default)
        {
            return await _context.Schedules.Where(x => x.EndTime == endTime && !x.isDeleted).ToListAsync(cancellationToken);
        }
    }
}
