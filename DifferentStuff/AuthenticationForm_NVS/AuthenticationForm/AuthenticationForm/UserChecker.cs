using AuthenticationForm.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AuthenticationForm
{
    public class UserChecker
    {
        private UserDbContext context = new UserDbContext();
        public bool Check(User userInput)
        {
            var passwordHasher = new PasswordHasher();

            var hashedPassword = passwordHasher.Hash(userInput.Password);
            var user = context.Users.FirstOrDefault(u => u.Name.Equals(userInput.Name));

            if (user == null)
                return false;

            if (user.Password.Equals(hashedPassword))
                return true;
            else
                return false;
        }
    }
}
