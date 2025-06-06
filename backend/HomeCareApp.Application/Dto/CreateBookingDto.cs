namespace HomeCareApp.Application.Dto;

public class CreateBookingDto
{
    public required Guid RequestId { get; set; }
    public required Guid ProviderId { get; set; }
}