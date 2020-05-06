using planningpoker.TOs;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace planningpoker.Models
{
    public class User
    {
        public string Id { get; set;}
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }

        public UserTO ToTo()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            var userTo = new UserTO {
                Login = Convert.ToBase64String(salt)
            };
            return userTo;
        }
    }
}