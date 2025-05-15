namespace HomeCareApp.Application.Dto;

public class CreateBookingDto
{
    public required Guid RequestId { get; set; }
    public required Guid ProviderId { get; set; }
    public required DateTime RequestedDate { get; set; }
    public required string Status { get; set; } =  string.Empty;
    
}