using ContactsManager.Application.Interfaces.Commands;
using System.Threading.Tasks;

namespace ContactsManager.Application.Commands.UpdateContact
{
    public class UpdateContactCommandHandler : ICommandHandler<UpdateContactCommand>
    {
        public Task Handle(UpdateContactCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
