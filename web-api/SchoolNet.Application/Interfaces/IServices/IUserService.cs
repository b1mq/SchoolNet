using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Entities.Pattern_Repository;

namespace SchoolNet.Application.Interfaces.IServices
{
    public interface IUserService
    {
        Task<Result> AddNewUserAsync(UserDto dto)
    }
}
