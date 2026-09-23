using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Enums;

namespace SchoolNet.Application.Dtos.Auth
{
    public sealed record RegisterRequestDto(string Firstname, string Surname, DateOnly DateOfBirth, string Email, string Password, UserRole Role);
}
