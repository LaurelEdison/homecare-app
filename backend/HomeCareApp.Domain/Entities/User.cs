using HomeCareApp.Domain.Enums;

namespace HomeCareApp.Domain.Entities;

public class User
{
    // Parameterless constructor for ef core
    public User()
    {
        FullName = string.Empty;
        PasswordHash = string.Empty;
        Email = string.Empty;
    }

    private User(Guid id, Roles role, string fullName, string email, string password)
    {
        Id = id;
        Role = role;
        FullName = fullName;
        Email = email;
        PasswordHash = password;
    }

    public static User Create(Guid id, Roles role,  string fullName, string email, string password)
    {
        return new User(id,  role,  fullName, email, password);
    }
    
    public Guid Id { get; set; }
    public string FullName { get; set; } 
    public string PasswordHash { get; set; }
    public string Email { get; set; } 
    public Roles Role { get; set; }
    public string ProfilePicture { get; set; } = string.Empty;
    
    public ICollection<CareRequest>? CareRequests { get; set; } //Many requests for client
    public ICollection<Booking>? ProviderBookings { get; set; } //Many bookings if they are provider
}