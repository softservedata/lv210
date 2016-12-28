using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wow.Data
{
    public class User
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        // Constructor
        public User(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

    }
}
