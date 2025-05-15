using HomeCareApp.Domain.Entities;

namespace HomeCareApp.Application.Dto;

public class UserResponseDto
{
    public required Guid Id { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; } 
    public string? ProfilePicture { get; set; }
    
    public ICollection<CareRequest>? CareRequests { get; set; } //Many requests for client
    public ICollection<Booking>? ProviderBookings { get; set; } //Many bookings if they are provider
}