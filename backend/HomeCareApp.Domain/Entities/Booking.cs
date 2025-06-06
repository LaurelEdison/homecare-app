using System.ComponentModel.DataAnnotations.Schema;

namespace HomeCareApp.Domain.Entities;

public class Booking
{
    private Booking(Guid id, Guid requestId, Guid providerId)
    {
        Id = id;
        RequestId = requestId;
        ProviderId = providerId;
    }

    public static Booking Create(Guid id, Guid requestId, Guid providerId)
    {
        
        return new Booking(id, requestId, providerId);
    }

    public Guid Id { get; set; }
    public Guid RequestId { get; set; }
    public Guid ProviderId { get; set; }
    public DateTime? RequestedDate { get; set; }
    public string Status { get; set; } =  string.Empty;

    [ForeignKey(nameof(RequestId))]
    public CareRequest MCareRequest { get; set; } = null!;
    
    [ForeignKey(nameof(ProviderId))]
    public User Provider { get; set; } = null!;
    
    public ICollection<Review>? Reviews { get; set; }
    
    
}