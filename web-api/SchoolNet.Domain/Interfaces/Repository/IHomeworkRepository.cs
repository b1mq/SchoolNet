using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Entities.Spec;
using SchoolNet.Domain.Interfaces.Repository.CommonRepositories;

namespace SchoolNet.Domain.Interfaces.Repository
{
    public interface IHomeworkRepository:IRepository<Homework>
    {
        Task<IReadOnlyCollection<Homework>> GetByTitleAsync(string title,CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<Homework>> GetByContentAsync(string content,CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<Homework>> GetByClassSubjectId(int classsubjectId,CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<Homework>> GetByTeacherId(int teacherId,CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<Homework>> GetByDueDate(DateTime date,CancellationToken cancellationToken = default);
    }
}
