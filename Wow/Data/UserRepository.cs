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
        //
        //private const string CONNECTION_STRING = "Data Source=192.168.195.249;Database=WoWDB;User Id = wowtest; Password=wowtest;";
        //private const string CONNECTION_STRING = "Driver={SQL Server};Server=192.168.195.249;Database=WoWDB;Uid=wowtest;Pwd=wowtest;";
        private const string CONNECTION_STRING = "Driver={SQL Server};Server=192.168.103.142;Database=WoWDB;Uid=wowtest;Pwd=wowtest;";
        //private const string REQUEST_USERS = "SELECT U.Name, U.EMail, IIF(EXISTS(SELECT Name FROM Roles JOIN UserRole ON Roles.Id = UserRole.RoleId Where UserRole.UserId = U.Id and Name = 'Admin'),1,0) as IsAdmin, IIF(EXISTS(SELECT Name FROM Roles JOIN UserRole ON Roles.Id = UserRole.RoleId Where UserRole.UserId = U.Id and Name = 'Teacher'),1,0) as IsTeacher, IIF(EXISTS(SELECT Name FROM Roles JOIN UserRole ON Roles.Id = UserRole.RoleId Where UserRole.UserId = U.Id and Name = 'Student'),1,0) as IsStudent FROM[Users] as U JOIN UserRole ON U.Id = UserRole.UserId WHERE UserRole.RoleId= 1 ORDER BY U.Name";
        private const string REQUEST_USERS = "Select Firstname, Lastname, Language, Email, Password, IsAdmin, IsTeacher, IsStudent from Users;";

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

        public IList<IUser> FromDB()
        {
            return new UserUtils(string.Empty, new DBUtils(CONNECTION_STRING)).GetAllUsers(REQUEST_USERS);
            //return null;
        }

    }
}
