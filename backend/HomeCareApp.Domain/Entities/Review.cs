namespace HomeCareApp.Domain.Entities;

public class Review
{
    private Review(Guid id, Guid bookingId, int rating)
    {
        Id = id;
        BookingId = bookingId;
        Rating = rating;
    }

    public static Review Create(Guid id, Guid bookingId, int rating)
    {
        if (rating < 0)
        {
            throw new ArgumentException("Rating must be > 0");
        }
        if (rating > 6)
        {
            throw new ArgumentException("Rating must be < 6");
        }
        
        return new Review(id, bookingId, rating);
    }

    public Guid Id { get; set; }
    public Guid BookingId { get; set; }
    public int Rating { get; set; } //1-5
    public string? Comments { get; set; } = string.Empty;
}