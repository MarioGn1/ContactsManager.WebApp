using ContactsManager.Application.Exceptions;
using ContactsManager.Application.Interfaces.Commands;
using System;

namespace ContactsManager.Application.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider services;

        public CommandDispatcher(IServiceProvider service)
        {
            this.services = service;
        }
        public void Send<T>(T command) where T : ICommand
        {
            var handler = services.GetService(typeof(ICommandHandler<T>));

            if (handler != null)
                ((ICommandHandler<T>)handler).Handle(command);
            else
                throw new CommandException($"Command handler {command.GetType().Name} does not exist.");
        }
    }
}
