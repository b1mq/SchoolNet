using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Entities;
using SchoolNet.Domain.Interfaces.Repository.CommonRepositories;

namespace SchoolNet.Domain.Interfaces.Repository
{
    public interface ISubjectRepository:IRepository<Subject>
    {
        Task<Subject?> GetSubjectByTitleAsync(string title,CancellationToken cancellation = default);
     
    }
}
