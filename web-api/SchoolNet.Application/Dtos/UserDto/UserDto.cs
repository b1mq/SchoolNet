using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Enums;

namespace SchoolNet.Application.Dtos.UserDtos
{
    public sealed record UserDto(int Id, string FirstName, string Surname, DateOnly DateOfBirth, int Age, UserRole Role, int? ClassId) { };
}
