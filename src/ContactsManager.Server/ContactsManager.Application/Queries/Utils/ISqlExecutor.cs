using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactsManager.Application.Queries.Utils
{
    public interface ISqlExecutor
    {
        string DatabaseConnectionString { get; }
        public Task<SqlDataReader> ExecuteReader(SqlConnection connection, string query);
        public Task<SqlDataReader> ExecuteReader(SqlConnection connection, string query, Dictionary<string, object> parameters);
        public Task<object> ExecuteScalar(SqlConnection connection, string query, Dictionary<string, object> parameters);
    }
}
