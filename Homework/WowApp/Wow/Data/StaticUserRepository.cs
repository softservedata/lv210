﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wow.Data
{
    public sealed class StaticUserRepository
    {
        private static volatile StaticUserRepository instance;
        private static readonly Object synchronize = new Object();

        // constructor
        private StaticUserRepository()
        {
        }

        // static factory
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

        // not exist in DB
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
            //return new ExcelUtils("FileName").Load();
            return null;
        }

    }
}