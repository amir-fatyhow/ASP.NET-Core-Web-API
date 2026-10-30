namespace DefaultNamespace;

public interface IEventService
{
    IEnumerable<Event> GetAllEvents();
    Event? GetEventById(Guid id);
    Event CreateEvent(Event newEvent);
    bool UpdateEvent(Guid id, Event updatedEvent);
    bool DeleteEvent(Guid id);
}