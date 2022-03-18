using ContactsManager.Application.Common;
using ContactsManager.Application.Interfaces.Queries;
using ContactsManager.Application.Queries.Utils;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static ContactsManager.Application.Queries.Utils.SqlQueries;

namespace ContactsManager.Application.Queries.GetById
{
    public class GetByIdQueryHandler : ISingleResultQueryHandler<GetByIdQuery>
    {
        private readonly ISqlExecutor sqlExecutor;

        public GetByIdQueryHandler(ISqlExecutor sqlExecutor)
        {
            this.sqlExecutor = sqlExecutor;
        }

        public async Task<IResult> Handle(GetByIdQuery query)
        {
            var result = new ContactDetailsDisplay();

            using (SqlConnection connection = new SqlConnection(sqlExecutor.DatabaseConnectionString))
            {
                connection.Open();

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("userId", query.OwnerId);
                parameters.Add("contactId", query.ContactId);

                var reader = await sqlExecutor.ExecuteReader(connection, getByIdQuery, parameters);

                try
                {
                    if (reader.Read())
                    {
                        result.Id = (int)reader["Id"];
                        result.FirstName = reader["FirstName"] as string;
                        result.LastName = reader["LastName"] as string;
                        result.DateOfBirth = ((DateTime)reader["DateOfBirth"]).ToShortDateString();
                        result.PhoneNumber = reader["PhoneNumber"] as string;
                        result.Iban = reader["IBAN"] as string;
                        result.Street = reader["Street"] as string;
                        result.City = reader["City"] as string;
                        result.State = reader["State"] as string;
                        result.Country = reader["Country"] as string;
                        result.ZipCode = reader["ZipCode"] as string;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                {
                    return null;
                }
            }

            if (result == null)
            {
                return null;
            }

            return result;
        }
    }
}
