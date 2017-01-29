using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Wow.Data
{
    public class JsonUtils
    {
        private const string STORAGE_DIR = @"\FileStorage\";
        private string _storagePath;

        public JsonUtils(string fileName)
        {
            _storagePath = $"{STORAGE_DIR}{fileName}";
        }

        public IList<User> GetAllUsers()
        {
            string appDirPath = Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.SetupInformation.ApplicationBase));
            string fullPath = $"{appDirPath}{_storagePath}";
            return GetAllUsers(fullPath);
        }

        public IList<User> GetAllUsers(string fileName)
        {
            IList<User> users;
            DataContractJsonSerializer jsonser = new DataContractJsonSerializer(typeof(List<User>));
            using (Stream stream = new FileStream(fileName, FileMode.Open))
            {
                users = (IList<User>)jsonser.ReadObject(stream);
            }
            return users;
        }

        public static IList<User> xGetAllUsers(string fileName)
        {
            IList<User> users;
            DataContractJsonSerializer jsonser = new DataContractJsonSerializer(typeof(List<User>));
            using (Stream stream = new FileStream(fileName, FileMode.Open))
            {
                users = (List<User>)jsonser.ReadObject(stream);
            }
            return users;
        }
    }
}
