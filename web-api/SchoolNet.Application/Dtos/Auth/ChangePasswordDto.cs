using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolNet.Application.Dtos.Auth
{
    public sealed record ChangePasswordDto(string oldpassword, string newpassword) { };
}
