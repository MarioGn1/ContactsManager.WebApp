using ContactsManager.Application.Interfaces.Commands;
using System.Threading.Tasks;

namespace ContactsManager.Application.Commands.DeleteContact
{
    public class DeleteContactCommandHandler : ICommandHandler<DeleteContactCommand>
    {
        public Task Handle(DeleteContactCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
