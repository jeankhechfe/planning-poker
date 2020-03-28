using System;
using System.Collections.Generic;
using System.Linq;
using planningpoker.TOs;

namespace planningpoker.Models
{
    public class UserService
    {
        private readonly ProjectContext _projectContext;

        public UserService(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public UserTO Register(UserRegistrationTO userRegistrationTo)
        {
            var user = new User();
            user.Id = Guid.NewGuid().ToString();
            user.Login = userRegistrationTo.Login;

            _projectContext.Add(user);
            _projectContext.SaveChanges();

            return user.ToTo();
        }
        
        public LoginTO Login(UserLoginTO userLoginTo)
        {
            string login = userLoginTo.Login;
            var projectContextUsers = new List<User>(_projectContext.Users);
            User single = projectContextUsers.First(user => user.Login == login);
            
            //TODO actual password hash verification
            
            return new LoginTO(single.Id);
        }
    }
}