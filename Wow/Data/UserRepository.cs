using System;
using System.Collections.Generic;
using Wow.DataBase;

namespace Wow.Data
{
    public sealed class UserRepository 
    {
        private static volatile UserRepository instance;
        private static readonly Object synchronize = new Object();

        private UserRepository()
        {
        }

        // Static Factory
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
                .SetFirstName("LV-204")
                .SetLastName("ISTQB")
                .SetLanguage("English")
                .SetEmail("wowira@ukr.net")
                .SetPassword("irawow123")
                .SetIsAdmin(true)
                .SetIsTeacher(true)
                .SetIsStudent(true)
                .Build();
        }

        public IUser Invalid()
        {
            return User.Get()
                .SetFirstName("LV-204")
                .SetLastName("ISTQB")
                .SetLanguage("English")
                .SetEmail("wowa@ukr.net")
                .SetPassword("ir23")
                .SetIsAdmin(true)
                .SetIsTeacher(true)
                .SetIsStudent(true)
                .Build();
        }

        
        public IUser NewUser()
        {
            return User.Get()
                .SetFirstName("LV-204")
                .SetLastName("ISTQB")
                .SetLanguage("English")
                .SetEmail("wowa@ukr.net")
                .SetPassword("ir23")
                .SetIsAdmin(true)
                .SetIsTeacher(true)
                .SetIsStudent(true)
                .Build();
        }
    }
}
       