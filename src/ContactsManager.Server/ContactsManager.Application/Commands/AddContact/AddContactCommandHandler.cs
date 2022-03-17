using ContactsManager.Application.Exceptions;
using ContactsManager.Application.Interfaces.Commands;
using ContactsManager.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager.Application.Commands.AddContact
{
    public class AddContactCommandHandler : ICommandHandler<AddContactCommand>
    {
        private readonly ContactsManagerDbContext data;

        public AddContactCommandHandler(ContactsManagerDbContext data)
        {
            this.data = data;
        }

        public async Task Handle(AddContactCommand command)
        {
            var validator = new AddContactCommandValidator();
            var result = validator.Validate(command);
            bool validationSucceeded = result.IsValid;

            if (!validationSucceeded)
            {
                var failures = result.Errors.ToList();
                var message = new StringBuilder();
                failures.ForEach(f => { message.Append(f.ErrorMessage + Environment.NewLine); });
                throw new ValidationException(message.ToString());
            }

            var user = data.Users
                .Include(x => x.Book)
                .ThenInclude(x => x.Contacts)
                .FirstOrDefault(x => x.Id == command.OwnerId);            

            user.Book.Create(command.FirstName,
                    command.LastName,
                    command.DateOfBirth,
                    command.Street, command.City, command.State, command.Country, command.ZipCode,
                    command.PhoneNumber,
                    command.Iban);

            await data.SaveChangesAsync();
        }
    }
}
