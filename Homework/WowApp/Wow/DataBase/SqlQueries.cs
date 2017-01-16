using System;
using System.IO;
using System.Reflection;

namespace Wow.DataBase
{
    class SqlQueries
    {
        public static readonly string GetUsers;

        public static readonly string FindCountOfUsers;

        static SqlQueries()
        {
            GetUsers = ReadFromFile("DataBase\\GetAllQuery.txt");
            FindCountOfUsers = ReadFromFile("DataBase\\FindCountOfUsersQuery.txt");
        }

        private static string ReadFromFile(string fileName)
        {
            var path = CreatePath(fileName);
            string line;

            using (StreamReader reader = new StreamReader(path))
            {
                line = reader.ReadLine();
            }

            return line;
        }

        private static string CreatePath(string fileName)
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            var pathName = Path.GetDirectoryName(path);
            return Path.Combine(pathName, fileName);
        }
    }
}