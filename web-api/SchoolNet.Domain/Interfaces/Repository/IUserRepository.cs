using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Entities;
using SchoolNet.Domain.Interfaces.Repository.CommonRepositories;
namespace SchoolNet.Domain.Interfaces.Repository
{
    public interface IUserRepository:IRepository<User>
    {
        Task<User?> GetUserByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<User?> GetByEmailAsync(string email,CancellationToken cancellationToken = default);
        Task<bool> ExistsUserByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<User>> GetByClassIdAsync(int classId,CancellationToken cancellationToken = default);
    }
}
