using System;
using System.Collections.Generic;

namespace Wow.Data
{
    public sealed class StaticUserRepository
    {
        private static volatile StaticUserRepository instance;
        private static readonly Object synchronize = new Object();

        private StaticUserRepository() { }

        // Static factory
        public static StaticUserRepository Get()
        {
            if (instance == null)
            {
                lock (synchronize)
                {
                    if (instance == null)
                    {
                        instance = new StaticUserRepository();
                    }
                }
            }
            return instance;
        }

        public IUser Admin()
        {
            return User.Get()
                .SetEmail("wowira@ukr.net")
                .SetPassword("irawow123")
                .SetName("LV-204 ISTQB")
                .SetIsAdmin(true)
                .SetIsTeacher(true)
                .SetIsStudent(true)
                .Build();
        }

        public IUser Invalid()
        {
            return User.Get()
                .SetEmail("wow@i.ua")
                .SetPassword("qwerty")
                .SetName("some name")
                .SetIsAdmin(true)
                .SetIsTeacher(true)
                .SetIsStudent(true)
                .Build();
        }

        // Not exist in DB
        public IUser NewUser()
        {
            return User.Get()
                .SetEmail("new@gmail.com")
                .SetPassword("qwerty")
                .SetName("some name")
                .SetIsAdmin(true)
                .SetIsTeacher(true)
                .SetIsStudent(true)
                .Build();
        }

        public List<IUser> FromExcel()
        {
            // TODO
            return null;
        }
    }
}