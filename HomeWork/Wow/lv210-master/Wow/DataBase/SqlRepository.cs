using System;
using System.Data;
using System.Data.SqlClient;

namespace Wow.DataBase
{
    public abstract class SqlRepository
    {
        protected IRepositorySettings RepositorySettings;

        protected SqlRepository(IRepositorySettings repositorySettings)
        {
            RepositorySettings = repositorySettings;
        }

        protected void ExecuteDataReaderQuery(string queryText, SqlParameter[] parameters,
            Action<SqlDataReader> onReaderExecuted)
        {
            using (SqlConnection connection = new SqlConnection(RepositorySettings.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryText, connection))
                {
                    command.CommandType = CommandType.Text;

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        onReaderExecuted(reader);
                    }
                }
            }
        }

        protected int ExecuteScalar(string queryText, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(RepositorySettings.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryText, connection))
                {
                    command.CommandType = CommandType.Text;

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    return (int) command.ExecuteScalar();
                }
            }
        }

        protected SqlParameter CreateSqlParameter(string parameterName, object value, DbType dbType,
            ParameterDirection direction = ParameterDirection.Input)
        {
            return new SqlParameter(parameterName, value ?? DBNull.Value)
            {
                Direction = direction,
                DbType = dbType
            };
        }
    }
}