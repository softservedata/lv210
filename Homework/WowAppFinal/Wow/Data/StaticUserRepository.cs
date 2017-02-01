using System;
using System.Collections.Generic;

namespace Wow.Data
{
    public sealed class StaticUserRepository
    {
        private static volatile StaticUserRepository instance;
        private static readonly object Synchronize = new object();

        private StaticUserRepository() { }

        // Static factory
        public static StaticUserRepository Get()
        {
            if (instance == null)
            {
                lock (Synchronize)
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
                .SetFirstName("LV-204")
                .SetLastName("ISTQB")
                .SetLanguage("ghghgh")
                .SetEmail("wowira@ukr.net")
                .SetPassword("irawow123")
                .SetIsAdmin(true)
                .SetIsTeacher(true)
                .SetIsStudent(true)
                .Build();
        }

        public IUser Teacher()
        {
            return User.Get()
                .SetFirstName("natalia")
                .SetLastName("Babliak")
                .SetLanguage("English")
                .SetEmail("testernatalia@ukr.net")
                .SetPassword("qwerty123&")
                .SetIsAdmin(false)
                .SetIsTeacher(true)
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
                .SetIsStudent(true)
                .Build();
        }

        public IUser Invalid()
        {
            return User.Get()
                .SetFirstName("1234")
                .SetLastName("1234")
                .SetLanguage("English")
                .SetEmail("wow@i.ua")
                .SetPassword("qwerty")
                .SetIsAdmin(true)
                .SetIsTeacher(true)
                .SetIsStudent(true)
                .Build();
        }

        public IUser UserWithInvalidEmail()
        {
            return User.Get()
                .SetFirstName("Red")
                .SetLastName("Sun")
                .SetLanguage("English")
                .SetEmail("redsun")
                .SetPassword("redsun")
                .SetIsAdmin(true)
                .SetIsTeacher(true)
                .SetIsStudent(true)
                .Build();
        }

        // not exist in DB
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

        public IList<IUser> FromDefaultCsv()
        {
            return new UserUtils().GetAllUsers();
        }

        public IList<IUser> FromExcel()
        {
            //return new ExcelUtils("FileName").Load();
            return null;
        }
    }
}