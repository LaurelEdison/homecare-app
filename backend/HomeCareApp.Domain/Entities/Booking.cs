namespace HomeCareApp.Domain.Entities;

public class Booking
{
    public Guid Id { get; set; }
    public Guid RequestId { get; set; }
    public Guid ProviderId { get; set; }
    public DateTime ScheduledDate { get; set; }
    public string Status { get; set; } =  string.Empty;
}