using HomeCareApp.Domain.Entities;

namespace HomeCareApp.Application.Service.Implementations;

public interface IReviewService
{
    string Create(Guid bookingId, int rating);
    List<Review> GetAllByBookingId(Guid bookingId);
    string DeleteReview(Guid reviewId);
}