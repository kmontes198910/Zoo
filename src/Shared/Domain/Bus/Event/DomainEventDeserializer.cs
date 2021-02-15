namespace Shared.Domain.Bus.Event
{
    public interface DomainEventDeserializer
    {
        DomainEvent Deserialize(string domainEvent);
    }
}
