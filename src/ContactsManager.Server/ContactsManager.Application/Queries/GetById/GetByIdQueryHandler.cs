using ContactsManager.Application.Common;
using ContactsManager.Application.Interfaces.Queries;
using ContactsManager.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ContactsManager.Application.Queries.GetById
{
    public class GetByIdQueryHandler : ISingleResultQueryHandler<GetByIdQuery>
    {
        private readonly ContactsManagerDbContext data;

        public GetByIdQueryHandler(ContactsManagerDbContext data)
        {
            this.data = data;
        }

        public IResult Handle(GetByIdQuery query)
        {
            var user = data.Users
                .Include(x => x.Book)
                .ThenInclude(x => x.Contacts)
                .FirstOrDefault(x => x.Id == query.OwnerId);

            var contact = user.Book.GetById(query.ContactId);

            if (contact == null)
            {
                return null;
            }

            return new ContactDetailsDisplay
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                DateOfBirth = contact.DateOfBirth.ToShortDateString(),
                PhoneNumber = contact.PhoneNumber,
                Iban = contact.Iban,
                City = contact.Address.City,
                Street = contact.Address.Street,
                Country = contact.Address.Country,
                State = contact.Address.State,
                ZipCode = contact.Address.ZipCode,
            };
        }
    }
}
