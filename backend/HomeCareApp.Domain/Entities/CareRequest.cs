using System.ComponentModel.DataAnnotations.Schema;
using HomeCareApp.Domain.Enums;

namespace HomeCareApp.Domain.Entities;

public class CareRequest // Created by client
{
    private CareRequest(Guid id, Guid clientId, DateTime requestedDate, string address)
    {
        Id = id;
        ClientId = clientId;
        RequestedDate = requestedDate;
        Address = address;
    }

    public static CareRequest Create(Guid id, Guid clientId, DateTime requestedDate,  string address)
    {
        if (requestedDate < DateTime.Now)
        {
            throw new ArgumentException("Requested date must be in the future");
        }
        return new CareRequest(id, clientId, requestedDate,  address);
    }

    public Guid Id { get; set; }
    public Guid ClientId { get; set; }
    public DateTime RequestedDate { get; set; }
    public ServiceTypes ServiceType { get; set; } = ServiceTypes.Nursing;
    public string Notes { get; set; } = string.Empty;
    public string Address { get; set; } 

    [ForeignKey(nameof(ClientId))]
    public User Client { get; set; } = null!;
    
    //Many bookings because many providers can offer to take request
    public ICollection<Booking>? Bookings { get; set; } 
}