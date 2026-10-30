using ASP.NET_Core_Web_API.Dtos;
using ASP.NET_Core_Web_API.Models;

namespace ASP.NET_Core_Web_API.Interfaces;

public interface IEventService
{
    Task<IEnumerable<EventResponseDto>> GetAllEventsAsync(CancellationToken cancellationToken);
    Task<EventResponseDto?> GetEventByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<EventResponseDto> CreateEventAsync(CreateEventDto newEvent, CancellationToken cancellationToken);
    Task<bool> UpdateEventAsync(Guid id, UpdateEventDto updatedEvent, CancellationToken cancellationToken);
    Task<bool> DeleteEventAsync(Guid id, CancellationToken cancellationToken);
}