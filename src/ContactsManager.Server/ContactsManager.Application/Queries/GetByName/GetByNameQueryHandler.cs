using ContactsManager.Application.Common;
using ContactsManager.Application.Interfaces.Queries;
using ContactsManager.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ContactsManager.Application.Queries.GetByName
{
    public class GetByNameQueryHandler : IQueryHandler<GetByNameQuery>
    {
        private readonly ContactsManagerDbContext data;

        public GetByNameQueryHandler(ContactsManagerDbContext data)
        {
            this.data = data;
        }

        public IList<IResult> Handle(GetByNameQuery query)
        {
            var user = data.Users
                .Include(x => x.Book)
                .ThenInclude(x => x.Contacts)
                .FirstOrDefault(x => x.Id == query.OwnerId);

            var filteredContacts = user.Book.GetByName(query.Name);

            if (filteredContacts.Count == 0)
            {
                return null;
            }

            return filteredContacts
                .Select(x => new ContactDisplay
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName
                })
                .ToList<IResult>();
        }
    }
}
