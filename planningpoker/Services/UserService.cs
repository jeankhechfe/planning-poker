using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
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
            user.UserId = Guid.NewGuid().ToString();
            user.Username = userRegistrationTo._login;

            _projectContext.Add(user);
            _projectContext.SaveChanges();

            return user.ToTo();
        }

        public LoginTO Login(UserLoginTO userLoginTo)
        {
            string login = userLoginTo.Login;
            var projectContextUsers = new List<User>(_projectContext.Users);
            User single = projectContextUsers.First(user => user.Username == login);

            //TODO actual password hash verification

            return new LoginTO(single.UserId);
        }

        public string HashPassword(string password)
        {
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

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