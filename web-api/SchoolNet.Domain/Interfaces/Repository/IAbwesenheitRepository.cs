using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Entities.Spec;
using SchoolNet.Domain.Interfaces.Repository.CommonRepositories;

namespace SchoolNet.Domain.Interfaces.Repository
{
    public interface IAbwesenheitRepository:IRepository<Abwesenheit>
    {
        Task<IReadOnlyCollection<Abwesenheit>> GetByStudentIdAsync(int studentId,CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<Abwesenheit>> GetBySheduleIDAsync(int classsheduleId,CancellationToken cancellationToken = default);
    }
}
