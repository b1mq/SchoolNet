using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolNet.Infrastructure.Auth
{
    public class JWToptions
    {
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string SecretKey { get; set; } = string.Empty;
        public int AccesTokenExpirationMinutes { get; set; }
        public int RefreschTokenExpirationDays { get; set; }

    }
}
