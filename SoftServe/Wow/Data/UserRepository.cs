using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wow.Data
{
    public sealed class UserRepository
    {
        private static volatile UserRepository instance;
        private static readonly Object synchronize = new Object();

        // constructor
        private UserRepository()
        {
        }

        // static factory
        public static UserRepository Get()
        {
            if (instance == null)
            {
                lock (synchronize)
                {
                    if (instance == null)
                    {
                        instance = new UserRepository();
                    }
                }
            }
            return instance;
        }

        public IUser Admin()
        {
            return User.Get()
                .SetFirstname(null)
                .SetLastname(null)
                .SetLanguage(null)
                .SetEmail("wowira@ukr.net")
                .SetPassword("irawow123")
                .SetConfirmPassword("irawow123")
                .SetIsAdmin(true)
                .SetIsTeacher(true)
                .SetIsStudent(true)
                .Build();
        }

        // not exist in DB
        public IUser NewUser()
        {
            return User.Get()
                .SetFirstname("Red")
                .SetLastname("Sun")
                .SetLanguage("English")
                .SetEmail("mail@example.com")
                .SetPassword("redsun")
                .SetConfirmPassword("redsun")
                .SetIsAdmin(true)
                .SetIsTeacher(true)
                .SetIsStudent(true)
                .Build();
        }
    }
}
