using NLog;
using System;
using System.Collections.Generic;
using System.IO;

namespace Wow.Data
{
    public class UserUtils
    {
        private const string FILE_STORAGE = @"\FileStorage\";
        // Fields
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private string storageName;
        private IExternalData externalData;

        public UserUtils()
        {
            storageName = FILE_STORAGE + "Users.csv";
            externalData = new CsvUtils();
        }

        public UserUtils(string storageName, IExternalData externalData)
        {
            this.storageName = FILE_STORAGE + storageName;
            this.externalData = externalData;
        }

        public IList<IUser> GetAllUsers()
        {
            string path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.SetupInformation.ApplicationBase)));
            return GetAllUsers(path + storageName);
        }

        public IList<IUser> GetAllUsers(string path)
        {
            logger.Debug("Start GetAllUsers, path = " + path);
            Console.WriteLine("path = " + path);
            IList<IUser> users = new List<IUser>();
            foreach (IList<string> row in externalData.GetAllCells(path))
            {
                if (row[3].ToLower().Equals("email")
                        && row[4].ToLower().Equals("password"))
                {
                    continue;
                }
                users.Add(User.Get()
                        .SetFirstname(row[0])
                        .SetLastname(row[1])
                        .SetLanguage(row[2])
                        .SetEmail(row[3])
                        .SetPassword(row[4])
                        .SetIsAdmin(row[5].ToLower().Equals("true"))
                        .SetIsTeacher(row[6].ToLower().Equals("true"))
                        .SetIsStudent(row[7].ToLower().Equals("true"))
                        .Build());
                logger.Debug("Add User Firstname= " + row[0] + " Lastname = " + row[1] + " Email = " + row[3]);
            }
            logger.Debug("Done GetAllUsers, path = " + path);
            return users;
        }
    }
}
