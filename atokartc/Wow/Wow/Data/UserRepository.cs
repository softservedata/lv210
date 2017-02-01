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
                .SetFirstname("LV-204")
                .SetLastname("ISTQB")
                .SetLanguage("English")
                .SetEmail("wowira@ukr.net")
                .SetPassword("irawow123")
                .SetIsAdmin(true)
                .SetIsTeacher(true)
                .SetIsStudent(true)
                .Build();
        }

        public IUser Student()
        {
            return User.Get()
                .SetFirstname("aaaaaa")
                .SetLastname("aaaaaa")
                .SetLanguage("English")
                .SetEmail("k2854799@mvrht.com")
                .SetPassword("qwerty+1")
                .SetIsAdmin(false)
                .SetIsTeacher(false)
                .SetIsStudent(true)
                .Build();
        }

        public IUser Teacher()
        {
            return User.Get()
                .SetFirstname("Mariana")
                .SetLastname("Medynska")
                .SetLanguage("English")
                .SetEmail("mar_yanap@yahoo.de")
                .SetPassword("q2w3e4r5")
                .SetIsAdmin(false)
                .SetIsTeacher(true)
                .SetIsStudent(false)
                .Build();
        }

        public IUser Invalid()
        {
            return User.Get()
                .SetFirstname("1234")
                .SetLastname("1234")
                .SetLanguage("English")
                .SetEmail("wow@i.ua")
                .SetPassword("qwerty")
                .SetIsAdmin(true)
                .SetIsTeacher(true)
                .SetIsStudent(true)
                .Build();
        }

        // not exist in DB
        public IUser NewUser()
        {
            return User.Get()
                .SetFirstname("")
                .SetLastname("")
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
            return new UserUtils("Users.xlsx", new ExcelUtils()).GetAllUsers();
            //return null;
        }

    }
}
