using System;
using Marketplace.Domain.Entities;

namespace Marketplace.App.Services.Handlers.Users
{
    public class CreateUserResponse
    {
        public Guid IdUser { get; set; }
        public string UserName { get; set; }

        public static explicit operator CreateUserResponse(User u) =>
            new CreateUserResponse()
            {
                IdUser = u.Id,
                UserName = u.Name
            };
    }
}
