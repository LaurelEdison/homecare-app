using HomeCareApp.Domain.Entities;
using HomeCareApp.Domain.Interfaces;

namespace HomeCareApp.Application.Service.Implementations;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _repository;

    public ReviewService(IReviewRepository repository)
    {
        _repository = repository;
    }

    public string Create(Guid bookingId, int rating)
    {
        var review = Review.Create(Guid.NewGuid(), bookingId, rating);
        return _repository.Add(review);
    }

    public List<Review> GetAllByBookingId(Guid bookingId)
    {
        return _repository.GetAllByBookingId(bookingId);
    }

    public string DeleteReview(Guid reviewId)
    {
        return _repository.Delete(reviewId);
    }
    
}