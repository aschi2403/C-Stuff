using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AuthenticationForm.Model;

namespace AuthenticationForm
{
    public class UserCreator
    {
        private UserDbContext context = new UserDbContext();
        public bool Create(string username, string password)
        {
            var userCheck = context.Users.FirstOrDefault(u => u.Name.Equals(username));
            if (userCheck != null)
                return false;

            var passwordHasher = new PasswordHasher();

            var user = new User
            {
                Name = username,
                Password = passwordHasher.Hash(password)
            };

            try
            {
                context.Users.Add(user);
                context.SaveChanges();
            } catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}
