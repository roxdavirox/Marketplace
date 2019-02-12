using Marketplace.Domain.Entities;
using Newtonsoft.Json;
using System;

namespace Marketplace.App.Handlers.Users
{
    public class AuthUserResponse
    {
        public Guid IdUser { get; set; }
        public string UserName { get; set; }

        public static explicit operator AuthUserResponse(User u) =>
            new AuthUserResponse
            {
                IdUser = u.Id,
                UserName = u.Name
            };
    }

    public static class _AuthResponse
    {
        public static string ToJson(this AuthUserResponse authUser) =>
           JsonConvert.SerializeObject(
                new
                {
                    userId = authUser.IdUser,
                    userName = authUser.UserName
                });
    }
}
