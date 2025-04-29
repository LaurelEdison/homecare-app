using System.ComponentModel.DataAnnotations.Schema;

namespace HomeCareApp.Domain.Entities;

public class Booking
{
    private Booking(Guid id, Guid requestId, Guid providerId, DateTime requestedDate)
    {
        Id = id;
        RequestId = requestId;
        ProviderId = providerId;
        RequestedDate = requestedDate;
    }

    public static Booking Create(Guid id, Guid requestId, Guid providerId, DateTime requestedDate)
    {
        if (requestedDate < DateTime.Now)
        {
            throw new ArgumentException("Requested date must be in the future");
        }
        
        return new Booking(id, requestId, providerId, requestedDate);
    }

    public Guid Id { get; set; }
    public Guid RequestId { get; set; }
    public Guid ProviderId { get; set; }
    public DateTime RequestedDate { get; set; }
    public string Status { get; set; } =  string.Empty;

    [ForeignKey(nameof(RequestId))]
    public CareRequest MCareRequest { get; set; } = null!;
    
    [ForeignKey(nameof(ProviderId))]
    public User Provider { get; set; } = null!;
    
    public ICollection<Review>? Reviews { get; set; }
    
    
}