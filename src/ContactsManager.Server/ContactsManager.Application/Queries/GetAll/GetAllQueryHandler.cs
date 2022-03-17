using ContactsManager.Application.Common;
using ContactsManager.Application.Interfaces.Queries;
using ContactsManager.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ContactsManager.Application.Queries.GetAll
{
    public class GetAllQueryHandler : IQueryHandler<GetAllQuery>
    {
        private readonly ContactsManagerDbContext data;

        public GetAllQueryHandler(ContactsManagerDbContext data)
        {
            this.data = data;
        }

        public IList<IResult> Handle(GetAllQuery query)
        {
            var user = data.Users
               .Include(x => x.Book)
               .ThenInclude(x => x.Contacts)
               .FirstOrDefault(x => x.Id == query.OwnerId);

            var allContacts = user.Book.Contacts
                .Select(x => new ContactDisplay
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                })
                .ToList<IResult>(); ;

            if (allContacts.Count == 0)
            {
                return null;
            }

            return allContacts;
        }
    }
}
