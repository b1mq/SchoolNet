using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Enums;

namespace SchoolNet.Application.Dtos.UserDtos
{
    public sealed record CreateUserDto(string Firstname, string Surname, DateOnly DateOfBirth, string Password, UserRole Role,string Email);
}
