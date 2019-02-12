﻿using Marketplace.Domain.Entities.Base;
using Marketplace.Domain.Validators;

namespace Marketplace.Domain.Entities
{
    public class User : EntityBase
    {
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;

            Validate(this, new UserValidator());
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

    }
}
