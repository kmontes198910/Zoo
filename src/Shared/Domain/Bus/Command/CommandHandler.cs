using System.Threading.Tasks;

namespace Shared.Domain.Bus.Command
{
    public interface CommandHandler<TCommand> where TCommand : global::Shared.Domain.Bus.Command.Command
    {
        Task Handle(TCommand command);
    }
}
