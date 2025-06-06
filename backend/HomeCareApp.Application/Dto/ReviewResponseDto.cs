namespace HomeCareApp.Application.Dto;

public class ReviewResponseDto
{
    public required Guid BookingId { get; set; }
    public required int Rating { get; set; } //1-5
    public required string? Comments { get; set; } = string.Empty; 
    public string ClientName { get; set; } = string.Empty;
}