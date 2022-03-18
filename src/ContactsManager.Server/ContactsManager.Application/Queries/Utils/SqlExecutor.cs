using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactsManager.Application.Queries.Utils
{
    public class SqlExecutor : ISqlExecutor
    {
        private readonly string databaseConnectionString;

        public SqlExecutor(string connectionString)
        {
            databaseConnectionString = connectionString;
        }

        public string DatabaseConnectionString => databaseConnectionString;

        public async Task<SqlDataReader> ExecuteReader(SqlConnection connection, string query)
        {
            try
            {
                var command = new SqlCommand(query, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                return reader;
            }
            catch
            {
                return null;
            }
        }

        public async Task<SqlDataReader> ExecuteReader(SqlConnection connection, string query, Dictionary<string, object> parameters)
        {
            try
            {
                var command = new SqlCommand(query, connection);
                SetParameters(command, parameters);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                return reader;
            }
            catch
            {
                return null;
            }
        }

        private void SetParameters(SqlCommand command, Dictionary<string, object> parameters)
        {
            foreach (var item in parameters)
            {
                command.Parameters.AddWithValue(item.Key, item.Value);
            }
        }
    }
}
