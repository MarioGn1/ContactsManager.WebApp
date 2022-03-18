using ContactsManager.Application.Common;
using ContactsManager.Application.Interfaces.Queries;
using ContactsManager.Application.Queries.Utils;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using static ContactsManager.Application.Queries.Utils.SqlQueries;

namespace ContactsManager.Application.Queries.GetAll
{
    public class GetAllQueryHandler : IQueryHandler<GetAllQuery>
    {
        private readonly ISqlExecutor sqlExecutor;

        public GetAllQueryHandler(ISqlExecutor sqlExecutor)
        {
            this.sqlExecutor = sqlExecutor;
        }

        public async Task<IList<IResult>> Handle(GetAllQuery query)
        {
            var result = new List<IResult>();

            using (SqlConnection connection = new SqlConnection(sqlExecutor.DatabaseConnectionString))
            {
                connection.Open();

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("userId", query.OwnerId);

                var reader = await sqlExecutor.ExecuteReader(connection, getAllContactsQuery, parameters);

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
