﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelloWorld.Models;    // Added

namespace HelloWorld
{
    public interface IUserRepository
    {
        User LogIn(string email, string password);
    }

    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> Users
        {
            get
            {
                var items = new[]
                {
                    new User{ Id=100, Email="admin", Password="admin", IsAdmin = true},
                    new User{ Id=101, Email="mike", Password="mike", IsAdmin = false},
                    new User{ Id=102, Email="dave", Password="dave", IsAdmin = false},
                    new User{ Id=103, Email="lisa", Password="lisa", IsAdmin = false},
                };
                return items;
            }
        }

        public User LogIn(string email, string password)
        {
            return Users.SingleOrDefault(t => t.Email.ToLower() == email.ToLower()
                                        && t.Password == password);
        }
    }

}