using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolNet.Application.Dtos.Auth
{
    public sealed record LoginRequestDto(string Email, string Password);
}
