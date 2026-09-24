using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Entities.Spec;
using SchoolNet.Domain.Interfaces.Repository.CommonRepositories;

namespace SchoolNet.Domain.Interfaces.Repository
{
    public interface IGradeRepository:IRepository<Grade>
    {
        Task<IReadOnlyCollection<Grade>> GetByStudentIdAsync(int studentId, CancellationToken cancellation = default);
        Task <IReadOnlyCollection<Grade>> GetByClassSubjectIdAsync(int classsubjectId, CancellationToken cancellation = default);
    }
}
