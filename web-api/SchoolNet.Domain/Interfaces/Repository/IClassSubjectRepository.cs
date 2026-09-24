using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Entities;
using SchoolNet.Domain.Interfaces.Repository.CommonRepositories;

namespace SchoolNet.Domain.Interfaces.Repository
{
    public interface IClassSubjectRepository:IRepository<ClassSubject>
    {
        Task<IReadOnlyCollection<ClassSubject>> GetByClassIdAsync(int classid,CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<ClassSubject>> GetBySubjectIdAsync(int  subjectid,CancellationToken cancellationToken = default);
    }
}
