using Marketplace.App.Handlers.Users;
using Marketplace.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace Marketplace.App.Services.Jwt
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtService(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public object CreateJwt(AuthUserResponse authUser)
        {
            var claimsIdentity = GetClaimsIdentity(authUser);

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
                userName = authUser.UserName
            };
        }

        private ClaimsIdentity GetClaimsIdentity(AuthUserResponse authUser)
        {
            var jtiClaim = new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString());

            var userClaim = new Claim("user", JsonConvert.SerializeObject(authUser));

            var claims = new[] { jtiClaim, userClaim };

            var genericIdentity = new GenericIdentity(authUser.ToString(), "Id");

            var claimsIdentity = new ClaimsIdentity(genericIdentity, claims);

            return claimsIdentity;
        }
    }
}
