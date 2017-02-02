using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Wow.DataBase;
using Wow.Helpers;

namespace Wow.Data
{
    public class DbUserRepository : SqlRepository, IDbUserRepository
    {
        public DbUserRepository(IRepositorySettings repositorySettings) : base(repositorySettings) { }

        #region IUserRepository

        public List<User> GetAll()
        {
            var users = new List<User>();

            ExecuteDataReaderQuery(SqlQueries.GetUsers, null, (reader) =>
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
            return ExecuteScalar(SqlQueries.FindCountOfUsers);
        }

        #endregion

        #region Helpers

        public User PopulateUserEntity(SqlDataReader reader)
        {
            var user =
                User.Get()
                    .SetEmail(reader["EMail"].FromDb<string>())
                    .SetPassword(null)
                    .SetName(reader["Name"].FromDb<string>())
                    .SetIsAdmin(Convert.ToBoolean(reader["IsAdmin"].FromDb<int>()))
                    .SetIsTeacher(Convert.ToBoolean(reader["IsTeacher"].FromDb<int>()))
                    .SetIsStudent(Convert.ToBoolean(reader["IsStudent"].FromDb<int>()))
                    .Build();

            return user;
        }

        #endregion
    }
}
