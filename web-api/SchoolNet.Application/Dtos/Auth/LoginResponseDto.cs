using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Application.Dtos.UserDtos;

namespace SchoolNet.Application.Dtos.Auth
{
    public sealed record LoginResponseDto(string AccesToken,string RefreshToken, UserDto User);
}
