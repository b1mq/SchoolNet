using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Entities;
using SchoolNet.Domain.Interfaces.Repository.CommonRepositories;

namespace SchoolNet.Domain.Interfaces.Repository
{
    public interface ISchoolClassRepository:IRepository<SchoolClass>
    {
        Task<IReadOnlyCollection<SchoolClass>> GetByYearAsync(string  year,CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<SchoolClass>> GetByYearAndNameAsync(string name, string year, CancellationToken cancellation = default);
        Task<bool> ExistsByYearAndName(string year,string name,CancellationToken cancellation = default);
    }
}
