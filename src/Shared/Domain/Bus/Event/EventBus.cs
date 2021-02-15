using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared.Domain.Bus.Event
{
    public interface EventBus
    {
        Task Publish(List<DomainEvent> events);
    }
}
