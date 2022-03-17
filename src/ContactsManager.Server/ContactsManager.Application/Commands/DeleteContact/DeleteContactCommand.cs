using ContactsManager.Application.Interfaces.Commands;

namespace ContactsManager.Application.Commands.DeleteContact
{
    public class DeleteContactCommand : ICommand
    {
        public string OwnerId { get; set; }
        public int ContactId { get; set; }
    }
}
