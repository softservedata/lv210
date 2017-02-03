using System;
using System.Collections.Generic;
using System.IO;

namespace Wow.Data
{
    
    public class UserUtils
    {
        private const string FileStorage = @"\FileStorage\";
        private readonly string storageName;
        private readonly IExternalData externalData;

        public UserUtils()
        {
            storageName = FileStorage + "Users.csv";
            externalData = new CsvUtils();
        }

        public UserUtils(string storageName, IExternalData externalData)
        {
            this.storageName = FileStorage + storageName;
            this.externalData = externalData;
        }

        public IList<IUser> GetAllUsers()
        {
            string path =
                Path.GetDirectoryName(
                    Path.GetDirectoryName(
                        Path.GetDirectoryName(AppDomain.CurrentDomain.SetupInformation.ApplicationBase)));
            return GetAllUsers(path + storageName);
        }

        public IList<IUser> GetAllUsers(string path)
        {
            Console.WriteLine("path = " + path);
            IList<IUser> users = new List<IUser>();
            IList<IList<string>> allCells = externalData.GetAllCells(path);

            foreach (IList<string> row in allCells)
            {
                if (row[3].ToLower().Equals("email")
                        && row[4].ToLower().Equals("password"))
                {
                    continue;
                }
                users.Add(User.Get()
                        .SetFirstName(row[0])
                        .SetLastName(row[1])
                        .SetLanguage(row[2])
                        .SetEmail(row[3])
                        .SetPassword(row[4])
                        .SetIsAdmin(row[5].ToLower().Equals("true"))
                        .SetIsTeacher(row[6].ToLower().Equals("true"))
                        .SetIsStudent(row[7].ToLower().Equals("true"))
                        .Build());
            }
            return users;
        }
    }
}