using System;
using System.Threading.Tasks;

namespace Shared.Domain.Bus.Command
{
    internal abstract class CommandHandlerWrapper
    {
        public abstract Task Handle(global::Shared.Domain.Bus.Command.Command command, IServiceProvider provider);
    }

    internal class CommandHandlerWrapper<TCommand> : CommandHandlerWrapper
        where TCommand : global::Shared.Domain.Bus.Command.Command
    {
        public override async Task Handle(global::Shared.Domain.Bus.Command.Command domainEvent, IServiceProvider provider)
        {
            var handler = (CommandHandler<TCommand>) provider.GetService(typeof(CommandHandler<TCommand>));
            await handler.Handle((TCommand) domainEvent);
        }
    }
}
