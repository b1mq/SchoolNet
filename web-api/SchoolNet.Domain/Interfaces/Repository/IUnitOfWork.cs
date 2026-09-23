using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolNet.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
