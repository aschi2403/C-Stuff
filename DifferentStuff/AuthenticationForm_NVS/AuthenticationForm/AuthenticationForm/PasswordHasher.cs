using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AuthenticationForm
{
    public class PasswordHasher
    {
       public string Hash(string password)
        {
            var hasher = SHA256.Create();

            var hashArray =  hasher.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Convert byte array to a string   
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashArray.Length; i++)
            {
                builder.Append(hashArray[i].ToString("x2"));
            }

            Console.WriteLine("Password Hash = " + builder);
            return builder.ToString();
        }
    }
}
