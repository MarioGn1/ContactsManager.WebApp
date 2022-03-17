using ContactsManager.Application.Exceptions;
using ContactsManager.Application.Interfaces.Commands;
using ContactsManager.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsManager.Application.Commands.DeleteContact
{
    public class DeleteContactCommandHandler : ICommandHandler<DeleteContactCommand>
    {
        private readonly ContactsManagerDbContext data;

        public DeleteContactCommandHandler(ContactsManagerDbContext data)
        {
            this.data = data;
        }

        public async Task Handle(DeleteContactCommand command)
        {
            var user = data.Users
                .Include(x => x.Book)
                .ThenInclude(x => x.Contacts)
                .FirstOrDefault(x => x.Id == command.OwnerId);

            var isExist = user.Book.Contacts.Any(x => x.Id == command.ContactId);

            if (!isExist)
            {
                throw new CommandException("Not existent contact Id.");
            }
            user.Book.Delete(command.ContactId);

            await data.SaveChangesAsync();
        }
    }
}
