using ASP.NET_Core_Web_API.Dtos;
using ASP.NET_Core_Web_API.Interfaces;
using ASP.NET_Core_Web_API.Models;

namespace ASP.NET_Core_Web_API.Services;

public class EventService : IEventService
{
    private static readonly List<Event> _events = new(); 

    public Task<IEnumerable<EventResponseDto>> GetAllEventsAsync(CancellationToken cancellationToken)
    {
        var result = _events.Select(e => MapToDto(e));
        return Task.FromResult(result);
    }

    public Task<EventResponseDto?> GetEventByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var ev = _events.FirstOrDefault(e => e.Id == id);
        return Task.FromResult(ev == null ? null : MapToDto(ev));
    }

    public Task<EventResponseDto> CreateEventAsync(CreateEventDto newEvent, CancellationToken cancellationToken)
    {
        var domainEvent = new Event
        {
            Title = newEvent.Title,
            Description = newEvent.Description,
            StartAt = newEvent.StartAt,
            EndAt = newEvent.EndAt
        };

        _events.Add(domainEvent);
        return Task.FromResult(MapToDto(domainEvent));
    }

    public Task<bool> UpdateEventAsync(Guid id, UpdateEventDto updatedEvent, CancellationToken cancellationToken)
    {
        var existingEvent = _events.FirstOrDefault(e => e.Id == id);
        if (existingEvent == null) return Task.FromResult(false);

        existingEvent.Title = updatedEvent.Title;
        existingEvent.Description = updatedEvent.Description;
        existingEvent.StartAt = updatedEvent.StartAt;
        existingEvent.EndAt = updatedEvent.EndAt;

        return Task.FromResult(true);
    }

    public Task<bool> DeleteEventAsync(Guid id, CancellationToken cancellationToken)
    {
        return Task.FromResult(_events.RemoveAll(e => e.Id == id) > 0);
    }

    private static EventResponseDto MapToDto(Event e)
    {
        return new EventResponseDto
        {
            Id = e.Id,
            Title = e.Title,
            Description = e.Description,
            StartAt = e.StartAt,
            EndAt = e.EndAt
        };
    }
}