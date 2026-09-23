using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Application.Dtos.UserDtos;
using SchoolNet.Domain.Entities.Pattern_Repository;

namespace SchoolNet.Application.Interfaces.IServices
{
    public interface IUserService
    {
        Task<Result> AddNewUserAsync(UserDto dto);
        Task<ResultGeneric<UserDto>> GetUserByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<ResultGeneric<UserDto>> GetUserByEmail(string email, CancellationToken cancellationToken = default);
    }
}
