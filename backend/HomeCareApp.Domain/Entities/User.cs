using System.Dynamic;
using HomeCareApp.Domain.Enums;

namespace HomeCareApp.Domain.Entities;

public class User
{
    private User(Guid id, Roles role)
    {
        Id = id;
        Role = role;
    }

    public static User Create(Guid id, Roles role)
    {
        return new User(id,  role);
    }
    
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty; 
    public string Email { get; set; } = string.Empty;
    public Roles Role { get; set; }
    public string ProfilePicture { get; set; } = string.Empty;
    
    public ICollection<CareRequest> CareRequests { get; set; } //Many requests for client
    public ICollection<Booking> ProviderBookings { get; set; } //Many bookings if they are provider
}