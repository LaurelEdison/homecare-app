using HomeCareApp.Domain.Entities;
using HomeCareApp.Domain.Enums;

namespace HomeCareApp.Application.Dto;

public class CareRequestResponseDto
{
    public Guid Id { get; set; }
    public required Guid ClientId { get; set; }
    public required DateTime RequestedDate { get; set; }
    public ServiceTypes ServiceType { get; set; } = ServiceTypes.Nursing;
    public string Notes { get; set; } = string.Empty;
    public required string Address { get; set; } 
    public ICollection<Booking>? Bookings { get; set; } 
}