using System;
using System.Collections.Generic;
using System.Text;
using SchoolNet.Application.Interfaces.IHasher;

namespace SchoolNet.Application.Services.PasswordHasher
{
    public sealed class PasswordHasher:IHasherService
    {
        public   string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password,12);
        }
        public  bool VerifyPassword(string password,string hash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
        }
    }
}
