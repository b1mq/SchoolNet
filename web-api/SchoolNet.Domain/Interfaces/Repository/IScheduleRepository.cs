using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Entities;
using SchoolNet.Domain.Interfaces.Repository.CommonRepositories;

namespace SchoolNet.Domain.Interfaces.Repository
{
    public interface IScheduleRepository:IRepository<Schedule>
    {
        Task<IReadOnlyCollection<Schedule>> GetByRoomIdAsync(int  roomId,CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<Schedule>> GetByTeacherIdAsync(int teacherId, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<Schedule>> GetByClassSubjectIdAsync(int ClassSubjectId,CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<Schedule>> GetByStartTimeAsync(TimeOnly startTime,CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<Schedule>> GetByEndTimeAsync(TimeOnly endTime, CancellationToken cancellationToken = default);
    }
}
