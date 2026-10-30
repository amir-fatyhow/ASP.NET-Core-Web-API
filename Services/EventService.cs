using ASP.NET_Core_Web_API.Interfaces;
using ASP.NET_Core_Web_API.Models;

namespace ASP.NET_Core_Web_API.Services;

public class EventService : IEventService
{
    private readonly List<Event> _events = new();

    public IEnumerable<Event> GetAllEvents()
    {
        return _events;
    }

    public Event? GetEventById(Guid id)
    {
        return _events.FirstOrDefault(e => e.Id == id);
    }

    public Event CreateEvent(Event newEvent)
    {
        _events.Add(newEvent);
        return newEvent;
    }

    public bool UpdateEvent(Guid id, Event updatedEvent)
    {
        var existingEvent = GetEventById(id);
        if (existingEvent == null) return false;

        existingEvent.Title = updatedEvent.Title;
        existingEvent.Description = updatedEvent.Description;
        existingEvent.StartAt = updatedEvent.StartAt;
        existingEvent.EndAt = updatedEvent.EndAt;

        return true;
    }

    public bool DeleteEvent(Guid id)
    {
        return _events.Remove(_events.FirstOrDefault(e => e.Id == id)!);
    }
}