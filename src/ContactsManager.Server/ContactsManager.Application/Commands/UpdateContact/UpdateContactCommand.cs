using ContactsManager.Application.Interfaces.Commands;
using System;

namespace ContactsManager.Application.Commands.UpdateContact
{
    public class UpdateContactCommand : ContactCommand
    {
        public int Id { get; set; }
    }
}
