using HomeCareApp.Domain.Entities;
using HomeCareApp.Domain.Enums;

namespace HomeCareApp.Application.Dto;

public class UserResponseDto
{
    public required Guid Id { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; } 
    public required Roles Role { get; set; }
    public string? ProfilePicture { get; set; }
    
    public List<CareRequest>? CareRequests { get; set; } //Many requests for client
    public List<Booking>? ProviderBookings { get; set; } //Many bookings if they are provider
}