using ASP.NET_Core_Web_API.Models;

namespace ASP.NET_Core_Web_API.Interfaces;

public interface IEventService
{
    IEnumerable<Event> GetAllEvents();
    Event? GetEventById(Guid id);
    Event CreateEvent(Event newEvent);
    bool UpdateEvent(Guid id, Event updatedEvent);
    bool DeleteEvent(Guid id);
}