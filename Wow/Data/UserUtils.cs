using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Wow.Data
{
    public class UserUtils
    {
        private const string FILE_STORAGE = @"\FileStorage\";
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
            // for main method
            //return GetAllUsers(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + storageName);
            // for test, ver 1
            //var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            //var uri = new UriBuilder(codeBase);
            //var path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Uri.UnescapeDataString(uri.Path))));
            // for test, ver 2
            string path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.SetupInformation.ApplicationBase)));
            return GetAllUsers(path + storageName);
        }

        public IList<IUser> GetAllUsers(string path)
        {
            Console.WriteLine("path = " + path);
            IList<IUser> users = new List<IUser>();
            foreach (IList<string> row in externalData.GetAllCells(path))
            {
                if (row[0].ToLower().Equals("email")
                        && row[1].ToLower().Equals("password"))
                {
                    continue;
                }
                users.Add(User.Get()
                        .SetEmail("wowira@ukr.net")
                        .SetPassword("irawow123")
                        .SetIsAdmin(true)
                        .SetIsTeacher(true)
                        .SetIsStudent(true)
                        .Build());
            }
            return users;
        }

    }
}
