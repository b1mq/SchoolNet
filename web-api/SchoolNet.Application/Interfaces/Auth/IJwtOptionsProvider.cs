using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Domain.Entities;

namespace SchoolNet.Application.Interfaces.Auth
{
    public  interface IJwtOptionsProvider
    {
        string GenerateAccessToken(User user);
        string GenerateRefreshToken();
    }
}
