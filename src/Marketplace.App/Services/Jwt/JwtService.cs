using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Marketplace.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Marketplace.App.Services.Jwt
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtService(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public object CreateJwt(User user)
        {
            var claimsIdentity = GetClaimsIdentity(user);

            var handler = new JwtSecurityTokenHandler();

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor()
            {
                Subject = claimsIdentity,
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = _jwtSettings.SigningCredentials,
                NotBefore = _jwtSettings.NotBefore,
                Expires = _jwtSettings.Expires
            });

            var accessToken = handler.WriteToken(securityToken);

            return new
            {
                authenticated = true,
                created = _jwtSettings.NotBefore.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = _jwtSettings.Expires.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken,
                message = "Ok",
                userName = user.Name
            };
        }

        private ClaimsIdentity GetClaimsIdentity(User user)
        {
            var jtiClaim = new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString());

            var userClaim = new Claim("usuario", JsonConvert.SerializeObject(user));

            var claims = new[] { jtiClaim, userClaim };

            var genericIdentity = new GenericIdentity(user.ToString(), "Id");

            var claimsIdentity = new ClaimsIdentity(genericIdentity, claims);

            return claimsIdentity;
        }
    }
}
