using HomeCareApp.Domain.Entities;

namespace HomeCareApp.Application.Dto;

public class BookingResponseDto
{
    public Guid Id { get; set; }
    public Guid RequestId { get; set; }
    public Guid ProviderId { get; set; }
    public DateTime RequestedDate { get; set; }
    public string Status { get; set; } =  string.Empty;
    public ICollection<Review>? Reviews { get; set; }
}