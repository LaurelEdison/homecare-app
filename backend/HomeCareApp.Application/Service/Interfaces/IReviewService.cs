using HomeCareApp.Domain.Entities;

namespace HomeCareApp.Application.Service.Implementations;

public interface IReviewService
{
    Task<Review> CreateAsync(Guid bookingId, int rating);
    Task<List<Review>> GetAllByBookingIdAsync(Guid bookingId);
    Task DeleteReviewAsync(Guid reviewId);
}