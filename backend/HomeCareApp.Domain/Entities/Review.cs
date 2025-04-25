namespace HomeCareApp.Domain.Entities;

public class Review
{
    public Guid Id { get; set; }
    public Guid BookingId { get; set; }
    public int Rating { get; set; } //1-5
    public string Comments { get; set; } = string.Empty;
    
    
}