using ASP.NET_Core_Web_API.Interfaces;
using ASP.NET_Core_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Web_API.Controllers;

[ApiController]
[Route("events")] 
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var events = _eventService.GetAllEvents();
        return Ok(events);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var ev = _eventService.GetEventById(id);
        if (ev == null) 
            return NotFound(); 

        return Ok(ev);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Event newEvent)
    {
        var createdEvent = _eventService.CreateEvent(newEvent);
        return CreatedAtAction(nameof(GetById), new { id = createdEvent.Id }, createdEvent);
    }

    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, [FromBody] Event updatedEvent)
    {
        var isUpdated = _eventService.UpdateEvent(id, updatedEvent);
        
        if (!isUpdated)
            return NotFound();

        return NoContent(); 
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var isDeleted = _eventService.DeleteEvent(id);
        
        if (!isDeleted)
            return NotFound();

        return NoContent(); 
    }
}