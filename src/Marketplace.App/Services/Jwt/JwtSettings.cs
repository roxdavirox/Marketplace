using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Marketplace.App.Services.Jwt
{
    public class JwtSettings
    {
        private readonly IConfiguration _configuration;

        public JwtSettings(IConfiguration configuration)
        {
            _configuration = configuration;

            Audience = _configuration["TokenSettings:Audience"];
            Issuer = _configuration["TokenSettings:Issuer"];
            Seconds = Convert.ToInt32(_configuration["TokenSettings:Seconds"]);

            var signingKey = _configuration["TokenSettings:SigningKey"];

            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));

            SigningCredentials = new SigningCredentials(
                    symmetricKey,
                    SecurityAlgorithms.HmacSha256Signature
                );
        }

        public string Audience { get; private set; }
        public string Issuer { get; private set; }
        public int Seconds { get; private set; }
        public DateTime NotBefore { get => DateTime.Now; }
        public DateTime Expires {
            get => NotBefore + TimeSpan.FromSeconds(Seconds);
        }

        public SigningCredentials SigningCredentials { get; private set; }

    }
}
