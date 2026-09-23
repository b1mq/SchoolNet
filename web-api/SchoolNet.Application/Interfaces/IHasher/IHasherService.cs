using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolNet.Application.Interfaces.IHasher
{
    public interface IHasherService
    {
         string HashPassword(string password);
         bool VerifyPassword(string password,string passwordHash);
    }
}
