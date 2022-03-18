using ContactsManager.Application.Common;
using ContactsManager.Application.Interfaces.Queries;
using ContactsManager.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            var filteredContacts = user.Book.GetByName(query.Name)
                .Select(x => new ContactDisplay
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                })
                .ToList<IResult>();

            if (filteredContacts.Count == 0)
            {
                return null;
            }

            return filteredContacts;                
        }

        Task<IList<IResult>> IQueryHandler<GetByNameQuery>.Handle(GetByNameQuery query)
        {
            throw new System.NotImplementedException();
        }
    }
}
