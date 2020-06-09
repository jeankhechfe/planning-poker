using planningpoker.TOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace planningpoker.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        public UserTO ToTo()
        {
            var userTo = new UserTO
            {
                Login = Username
            };
            return userTo;
        }
    }
}