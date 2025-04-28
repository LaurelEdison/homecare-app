using HomeCareApp.Domain.Enums;

namespace HomeCareApp.Domain.Entities;

public class CareRequest // Created by client
{
    private CareRequest(Guid id, Guid clientId, DateTime requestedDate)
    {
        Id = id;
        ClientId = clientId;
        RequestedDate = requestedDate;
    }

    public static CareRequest Create(Guid id, Guid clientId, DateTime requestedDate)
    {
        if (requestedDate < DateTime.Now)
        {
            throw new ArgumentException("Requested date must be in the future");
        }
        return new CareRequest(id, clientId, requestedDate);
    }

    public Guid Id { get; set; }
    public Guid ClientId { get; set; }
    public DateTime RequestedDate { get; set; }
    public Roles  ServiceType { get; set; } = Roles.Client;
    public string Notes { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    
    public User Client { get; set; }
    
    //Many bookings because many providers can offer to take request
    public ICollection<Booking> Bookings { get; set; } 
}