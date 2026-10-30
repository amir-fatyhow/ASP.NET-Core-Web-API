using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core_Web_API.Models;

public class Event : IValidatableObject
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required(ErrorMessage = "Title is required")]
    public required string Title { get; set; }
    
    public string? Description { get; set; }
    
    [Required(ErrorMessage = "StartAt is required")]
    public required DateTime StartAt { get; set; }
    
    [Required(ErrorMessage = "EndAt is required")]
    public required DateTime EndAt { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (EndAt <= StartAt)
        {
            yield return new ValidationResult(
                "EndAt must be later than StartAt", 
                new[] { nameof(EndAt) });
        }
    }
}