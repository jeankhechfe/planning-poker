using planningpoker.TOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace planningpoker.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        //public string Password { get; set; }
        public ICollection<Task> Tasks { get; set; }
        // public ICollection<Task> ProjectsPermissions { get; set; }

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