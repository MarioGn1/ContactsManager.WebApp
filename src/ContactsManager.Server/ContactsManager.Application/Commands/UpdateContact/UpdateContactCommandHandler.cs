using ContactsManager.Application.Exceptions;
using ContactsManager.Application.Interfaces.Commands;
using ContactsManager.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager.Application.Commands.UpdateContact
{
    public class UpdateContactCommandHandler : ICommandHandler<UpdateContactCommand>
    {
        private readonly ContactsManagerDbContext data;

        public UpdateContactCommandHandler(ContactsManagerDbContext data)
        {
            this.data = data;
        }

        public async Task Handle(UpdateContactCommand command)
        {
            var validator = new ContactCommandValidator();
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

            var isExist = user.Book.Contacts.Any(x => x.Id == command.Id);

            if (!isExist)
            {
                throw new CommandException("Not existent contact Id.");
            }

            user.Book.Update(command.Id,
                    command.FirstName,
                    command.LastName,
                    command.DateOfBirth,
                    command.Street, command.City, command.State, command.Country, command.ZipCode,
                    command.PhoneNumber,
                    command.Iban);

            await data.SaveChangesAsync();
        }
    }
}
