using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.Helpers
{
    public class TokenManagement
    {
        public string KeySecret { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int ValidityInMinutes { get; set; }
        public int RefreshTokenValidityInDays { get; set; }
    }
}
