namespace HomeCareApp.Application.Dto;

public class ReviewResponseDto
{
    public Guid BookingId { get; set; }
    public int Rating { get; set; } //1-5
    public string? Comments { get; set; } = string.Empty;
}