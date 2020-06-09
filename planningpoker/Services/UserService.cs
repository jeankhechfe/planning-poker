using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using planningpoker.Controllers.Exceptions;
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

        public List<User> GetAll()
        {
            return new List<User>(_projectContext.Users);
        }


        public User GetUser(string userId)
        {
            User user = _projectContext.Users.Find(userId);
            if (user == null)
                throw new NotFoundException("User of id " + userId + " does not exist");
            
            return user;
        }
        
        public LoginTO Register(UserRegistrationTO userRegistrationTo)
        {
            var user = new User();
            user.Id = Guid.NewGuid().ToString();
            user.Username = userRegistrationTo.login;
            user.PasswordHash = HashPassword(user.Id, userRegistrationTo.password);

            _projectContext.Add(user);
            _projectContext.SaveChanges();

            return new LoginTO(user.Id);
        }

        public LoginTO Login(UserLoginTO userLoginTo)
        {
            string login = userLoginTo.Login;
            var projectContextUsers = new List<User>(_projectContext.Users);
            User single = projectContextUsers.First(user => user.Username == login);

            var hashPassword = HashPassword(single.Id, userLoginTo.Password);
            
            if(hashPassword != single.PasswordHash)
                throw new AccessForbiddenException();
            
            return new LoginTO(single.Id);
        }

        public string HashPassword(string uid, string password)
        {
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = Encoding.ASCII.GetBytes(uid);

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}