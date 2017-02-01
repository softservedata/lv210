using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Wow.DataBase;
using Wow.Helpers;

namespace Wow.Data
{
    public class UserRepository : SqlRepository, IUserRepository
    {
        public UserRepository(IRepositorySettings repositorySettings) : base(repositorySettings) { }

        #region IUserRepository

        public IList<IUser> GetAll()
        {
            var users = new List<IUser>();

            this.ExecuteDataReaderQuery(SqlQueries.GetUsers, null,
                (reader) =>
                    {
                        while (reader.Read())
                        {
                            users.Add(this.PopulateUserEntity(reader));
                        }
                    });

            return users;
        }

        public int FindCountOfUsers()
        {
            return this.ExecuteScalar(SqlQueries.FindCountOfUsers);
        }

        #endregion

        #region Helpers

        public IUser PopulateUserEntity(SqlDataReader reader)
        {
            // Entity 'User' from DB has only full name, but User from
            // this framework has first and last name. This code divides full name on two parts.

            string fullName = reader["Name"].FromDb<string>();
            string name = fullName.GetMatch(User.FirstNameRegex).Trim();
            string surname = fullName.GetMatch(User.LastNameRegex).Trim();

            var user =
                User.Get()
                    .SetFirstName(name)
                    .SetLastName(surname)
                    .SetLanguage(string.Empty)
                    .SetEmail(reader["EMail"].FromDb<string>())
                    .SetPassword(string.Empty)
                    .SetIsAdmin(Convert.ToBoolean(reader["IsAdmin"].FromDb<int>()))
                    .SetIsTeacher(Convert.ToBoolean(reader["IsTeacher"].FromDb<int>()))
                    .SetIsStudent(Convert.ToBoolean(reader["IsStudent"].FromDb<int>()))
                    .Build();

            return user;
        }

        #endregion
    }
}
