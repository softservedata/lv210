using System;
using System.Collections.Generic;

namespace Wow.Data
{
    public sealed class UserRepository
    {
        private static volatile UserRepository instance;
        private static readonly Object synchronize = new Object();

        private UserRepository() { }

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
                .SetIsTeacher(false)
                .SetIsStudent(false)
                .Build();
        }

        public IUser Student()
        {
            return User.Get()
                .SetFirstName("aaaaaa")
                .SetLastName("aaaaaa")
                .SetLanguage("English")
                .SetEmail("k2854799@mvrht.com")
                .SetPassword("qwerty+1")
                .SetIsAdmin(false)
                .SetIsTeacher(false)
                .SetIsStudent(false)
                .Build();
        }

        public IUser Invalid()
        {
            return User.Get()
                .SetFirstName("123")
                .SetLastName("456")
                .SetLanguage("English")
                .SetEmail("wow@i.ua")
                .SetPassword("qwerty")
                .SetIsAdmin(true)
                .SetIsTeacher(true)
                .SetIsStudent(true)
                .Build();
        }

        // Not exist in DB
        public IUser NewUser()
        {
            return User.Get()
                .SetFirstName("")
                .SetLastName("")
                .SetLanguage("English")
                .SetEmail("new@gmail.com")
                .SetPassword("qwerty")
                .SetIsAdmin(true)
                .SetIsTeacher(true)
                .SetIsStudent(true)
                .Build();
        }

        public IList<IUser> FromCsv(string fileName)
        {
            return new UserUtils(fileName, new CsvUtils()).GetAllUsers();
        }

        public List<IUser> FromExcel()
        {
            // TODO
            return null;
        }
    }
}
