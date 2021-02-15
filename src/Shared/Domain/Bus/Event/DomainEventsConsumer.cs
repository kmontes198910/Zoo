using System.Threading.Tasks;

namespace Shared.Domain.Bus.Event
{
    public interface DomainEventsConsumer
    {
        Task Consume();
    }
}
