using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Entities;
using SchoolNet.Domain.Interfaces.Repository;
using SchoolNet.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using SchoolNet.Infrastructure.Repositories.CommonRepositories;
namespace SchoolNet.Infrastructure.Repositories
{
    public sealed class UserRepository:Repository<User>,IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
            :base(context)
        {
            _context = context;
        }
        public async Task<User?> GetUserByIdAsync(int id,CancellationToken cancellationToken = default)
        {
            return await _context.Users
                .FirstOrDefaultAsync(
                    x => x.Id == id && !x.isDeleted,
                    cancellationToken);
        }
        public async Task<User?> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken = default)
        {
            return await _context.Users
                .FirstOrDefaultAsync(
                    x => x.Email == email && !x.isDeleted,
                    cancellationToken);
        }

        public async Task<bool> ExistsUserByEmailAsync(
            string email,
            CancellationToken cancellationToken = default)
        {
            return await _context.Users
                .AnyAsync(
                    x => x.Email == email && !x.isDeleted,
                    cancellationToken);
        }

        public async Task<IReadOnlyCollection<User>> GetByClassIdAsync(
            int classId,
            CancellationToken cancellationToken = default)
        {
            return await _context.Users
                .Where(x => x.ClassId == classId && !x.isDeleted)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
