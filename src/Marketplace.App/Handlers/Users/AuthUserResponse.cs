using System;
using Marketplace.Domain.Entities;

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
}
