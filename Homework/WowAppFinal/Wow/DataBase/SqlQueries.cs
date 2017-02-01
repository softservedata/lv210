using System;
using System.IO;

namespace Wow.DataBase
{
    public class SqlQueries
    {
        public static readonly string GetUsers;
        public static readonly string FindCountOfUsers;
        public static readonly string FindCourseWithAppropriateName;

        static SqlQueries()
        {
            GetUsers = ReadFromFile("DataBase\\GetAllQuery.sql");
            FindCountOfUsers = ReadFromFile("DataBase\\FindCountOfUsersQuery.sql");
            FindCourseWithAppropriateName = ReadFromFile("DataBase\\FindCourseWithAppropriateName.sql");
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
            var pathName =
                Path.GetDirectoryName(
                    Path.GetDirectoryName(
                        Path.GetDirectoryName(AppDomain.CurrentDomain.SetupInformation.ApplicationBase)));
            return Path.Combine(pathName, fileName);
        }
    }
}