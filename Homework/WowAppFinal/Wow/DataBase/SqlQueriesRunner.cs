using Wow.Helpers;

namespace Wow.DataBase
{
    public class SqlQueriesRunner :SqlRepository
    {
        private const string ValueToReplace = "VALUE";

        public SqlQueriesRunner(IRepositorySettings repositorySettings) : base(repositorySettings) { }

        public bool IsCourseWithAppropriateNameInDb(string nameOfCourse)
        {
            string result = null;
            string query = SqlQueries.FindCourseWithAppropriateName.Replace(ValueToReplace, nameOfCourse);
            this.ExecuteDataReaderQuery(query,null,
                (reader) =>
                    {
                        if (reader.Read())
                        {
                            result = reader["Name"].FromDb<string>();
                        }
                    });

            return result != null;
        }
    }
}