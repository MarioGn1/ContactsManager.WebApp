using ContactsManager.Application.Exceptions;
using ContactsManager.Application.Interfaces.Commands;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ContactsManager.Application.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider services;

        public CommandDispatcher(IServiceProvider service)
        {
            this.services = service;
        }
        public async Task Send<T>(T command) where T : ICommand
        {
            var handler = services.GetService(typeof(ICommandHandler<T>));

            if (handler != null)
                try
                {
                    await ((ICommandHandler<T>)handler).Handle(command);
                }
                catch (ValidationException e)
                {
                    throw new CommandException(e.Message, e);
                }                
            else
                throw new CommandException($"Command handler {command.GetType().Name} does not exist.");
        }
    }
}
