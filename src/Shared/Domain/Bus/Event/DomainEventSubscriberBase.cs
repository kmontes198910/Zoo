using System.Threading.Tasks;

namespace Shared.Domain.Bus.Event
{
    public interface DomainEventSubscriberBase
    {
        Task On(DomainEvent @event);
    }
}
