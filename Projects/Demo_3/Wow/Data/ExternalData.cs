using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wow.Data
{
    public interface IExternalData
    {
        IList<IList<string>> GetAllValues(string path);
    }

    public static class FileStorage
    {
        private const string STORAGE_DIR = @"\FileStorage\";

        public static string GetPath(string fileName)
        {
            string appDirPath = Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.SetupInformation.ApplicationBase));
            string fullPath = $"{appDirPath}{STORAGE_DIR}{fileName}";
            return fullPath;
        }
    }
}