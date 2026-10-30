using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core_Web_API.Dtos;

public class CreateEventDto : IValidatableObject
{
    [Required(ErrorMessage = "Title is required")]
    [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
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
            yield return new ValidationResult("EndAt must be later than StartAt", new[] { nameof(EndAt) });
        }
    }
}