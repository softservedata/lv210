using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace Wow.Data
{
    public class DBUtils : IExternalData
    {
        private string connectionString;

        public DBUtils(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<IList<string>> GetAllCells(string path)
        {
            IList<IList<string>> allCells = new List<IList<string>>();
            //
            OdbcConnection connection = new OdbcConnection(connectionString);
            connection.Open();
            OdbcCommand command = new OdbcCommand(path, connection);
            OdbcDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                IList<string> rowCells = new List<string>();
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    rowCells.Add(dataReader.GetValue(i).ToString());
                }
                allCells.Add(rowCells);
            }
            dataReader.Close();
            connection.Close();
            command.Dispose();
            connection.Dispose();
            //
            return allCells;
        }

    }
}
