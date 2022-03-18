using ContactsManager.Application.Common;
using ContactsManager.Application.Interfaces.Queries;
using ContactsManager.Application.Queries.Utils;
using ContactsManager.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

using static ContactsManager.Application.Queries.Utils.SqlQueries;

namespace ContactsManager.Application.Queries.GetByName
{
    public class GetByNameQueryHandler : IQueryHandler<GetByNameQuery>
    {
        private readonly ISqlExecutor sqlExecutor;

        public GetByNameQueryHandler(ISqlExecutor sqlExecutor)
        {
            this.sqlExecutor = sqlExecutor;
        }

        public async Task<IList<IResult>> Handle(GetByNameQuery query)
        {
            var result = new List<IResult>();

            using (SqlConnection connection = new SqlConnection(sqlExecutor.DatabaseConnectionString))
            {
                connection.Open();

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("userId", query.OwnerId);
                parameters.Add("name", "%" + query.Name + "%");

                var reader = await sqlExecutor.ExecuteReader(connection, getByNameQuery, parameters);

                while (reader.Read())
                {
                    try
                    {
                        var currContact = new ContactDisplay
                        {
                            Id = (int)reader["Id"],
                            FirstName = reader["FirstName"] as string,
                            LastName = reader["LastName"] as string
                        };
                        result.Add(currContact);
                    }
                    catch
                    {
                        return null;
                    }
                }                
            }

            if (result.Count == 0)
            {
                return null;
            }

            return result;
        }
    }
}
