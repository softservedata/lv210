using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;

namespace Wow.Data
{
    public class JsonUtils
    {
        private string fileName;

        public JsonUtils(string fileName)
        {
            this.fileName = fileName;
        }

        public IList<IUser> GetAllUsers()
        {
            IList<User> users;
            string path = FileStorage.GetPath(fileName);
            DataContractJsonSerializer jsonser = new DataContractJsonSerializer(typeof(List<User>));
            using (Stream stream = new FileStream(path, FileMode.Open))
            {
                users = (IList<User>)jsonser.ReadObject(stream);
            }
            return users.ToList<IUser>();
        }
    }
}