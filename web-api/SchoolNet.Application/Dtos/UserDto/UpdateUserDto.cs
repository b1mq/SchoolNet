using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolNet.Application.Dtos.UserDtos
{
    public sealed record UpdateUserDto(string Firstname,string Surname,DateOnly dateOfBirth);
}
