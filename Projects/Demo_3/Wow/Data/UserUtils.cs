using System.Collections.Generic;

namespace Wow.Data
{
    public class UserUtils : UserPropertyIndex
    {
        private string fileName;
        private IExternalData externalData;

        public UserUtils(string fileName, IExternalData externalData)
        {
            this.fileName = fileName;
            this.externalData = externalData;
        }

        public IList<IUser> GetAllUsers()
        {
            IList<IUser> users = new List<IUser>();
            string path = FileStorage.GetPath(fileName);
            foreach (var item in externalData.GetAllValues(path))
            {
                if (item[Email].ToLower().Equals("email") &&
                    item[Password].ToLower().Equals("password"))
                    continue;
                users.Add(User.Get()
                    .SetFirstName(item[FirstName])
                    .SetLastName(item[LastName])
                    .SetLanguage(item[Language])
                    .SetEmail(item[Email])
                    .SetPassword(item[Password])
                    .SetIsAdmin(item[Admin].ToLower().Equals("true"))
                    .SetIsTeacher(item[Teacher].ToLower().Equals("true"))
                    .SetIsStudent(item[Student].ToLower().Equals("true"))
                    .Build());
            }
            return users;
        }
    }

    public class UserPropertyIndex
    {
        public byte FirstName { get; } = 0;
        public byte LastName { get; } = 1;
        public byte Language { get; } = 2;
        public byte Email { get; } = 3;
        public byte Password { get; } = 4;
        public byte Admin { get; } = 5;
        public byte Teacher { get; } = 6;
        public byte Student { get; } = 7;
    }
}