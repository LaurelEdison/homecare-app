using HomeCareApp.Application.Dto;
using HomeCareApp.Domain.Entities;

namespace HomeCareApp.Application.Service.Implementations;

public interface IReviewService
{
    string Create(CreateReviewDto dto);
    List<Review> GetAllByBookingId(Guid bookingId);
    string DeleteReview(Guid reviewId);
}