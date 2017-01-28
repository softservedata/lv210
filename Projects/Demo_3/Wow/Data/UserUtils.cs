using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wow.Data
{
    public class UserUtils
    {
        private const string STORAGE_DIR = @"\FileStorage\";
        private string _storagePath;
        private IExternalData _externalData;

        public UserUtils(string fileName, IExternalData externalData)
        {
            _storagePath = $"{STORAGE_DIR}{fileName}";
            _externalData = externalData;
        }

        public IList<IUser> GetAllUsers()
        {
            string appDirPath = Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.SetupInformation.ApplicationBase));
            string fullPath = $"{appDirPath}{_storagePath}";
            Console.WriteLine(appDirPath);
            Console.WriteLine(fullPath);
            return GetAllUsers(fullPath);
        }

        public IList<IUser> GetAllUsers(string path)
        {
            IList<IUser> users = new List<IUser>();
            foreach (var item in _externalData.GetAllValues(path))
            {
                if (item[3].ToLower().Equals("email") &&
                    item[4].ToLower().Equals("password"))
                    continue;
                users.Add(User.Get()
                    .SetFirstName(item[0])
                    .SetLastName(item[1])
                    .SetLanguage(item[2])
                    .SetEmail(item[3])
                    .SetPassword(item[4])
                    .SetIsAdmin(item[5].ToLower().Equals("true"))
                    .SetIsTeacher(item[6].ToLower().Equals("true"))
                    .SetIsStudent(item[7].ToLower().Equals("true"))
                    .Build());
            }
            return users;
        }
    }
}
