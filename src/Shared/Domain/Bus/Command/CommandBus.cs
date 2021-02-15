using System.Threading.Tasks;

namespace Shared.Domain.Bus.Command
{
    public interface CommandBus
    {
        Task Dispatch(global::Shared.Domain.Bus.Command.Command command);
    }
}
