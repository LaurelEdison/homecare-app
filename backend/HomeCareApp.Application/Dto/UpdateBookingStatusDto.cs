namespace HomeCareApp.Application.Dto;

public class UpdateBookingStatusDto
{
    public string Status { get; set; } = string.Empty;
    public Guid Id { get; set; }
}