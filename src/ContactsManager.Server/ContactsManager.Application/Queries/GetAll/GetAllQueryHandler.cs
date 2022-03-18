using ContactsManager.Application.Common;
using ContactsManager.Application.Interfaces.Queries;
using ContactsManager.Application.Queries.Utils;
using ContactsManager.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ContactsManager.Application.Queries.Utils.SqlQueries;

namespace ContactsManager.Application.Queries.GetAll
{
    public class GetAllQueryHandler : IQueryHandler<GetAllQuery>
    {
        private readonly ContactsManagerDbContext data;
        private readonly ISqlExecutor sqlExecutor;

        public GetAllQueryHandler(ContactsManagerDbContext data, ISqlExecutor sqlExecutor)
        {
            this.data = data;
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
                    var currContact = new ContactDisplay
                    {
                        Id = (int)reader["Id"],
                        FirstName = reader["FirstName"] as string,
                        LastName = reader["LastName"] as string
                    };
                    result.Add(currContact);
                }
            }
            

            //var user = data.Users
            //   .Include(x => x.Book)
            //   .ThenInclude(x => x.Contacts)
            //   .FirstOrDefault(x => x.Id == query.OwnerId);

            //var allContacts = user.Book.Contacts
            //    .Select(x => new ContactDisplay
            //    {
            //        Id = x.Id,
            //        FirstName = x.FirstName,
            //        LastName = x.LastName
            //    })
            //    .ToList<IResult>();

            if (result.Count == 0)
            {
                return null;
            }

            return result;
        }
    }
}
