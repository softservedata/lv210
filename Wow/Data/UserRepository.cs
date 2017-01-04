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
        private static Object synchronize = new Object();

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
                .SetEmail("new@gmail.com")
                .SetPassword("qwerty")
                .SetIsAdmin(true)
                .SetIsTeacher(true)
                .SetIsStudent(true)
                .Build();
        }

        public List<IUser> FromExcel()
        {
            //return new ExcelUtils("FileName").Load();
            return null;
        }

    }
}
