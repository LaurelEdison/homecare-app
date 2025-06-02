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

    public async Task<Review> CreateAsync(Guid bookingId, int rating)
    {
        var review = Review.Create(Guid.NewGuid(), bookingId, rating);
        await _repository.AddAsync(review);
        
        return review;
    }

    public async Task<List<Review>> GetAllByBookingIdAsync(Guid bookingId)
    {
        return await _repository.GetAllByBookingIdAsync(bookingId);
    }

    public async Task DeleteReviewAsync(Guid reviewId)
    {
        await _repository.DeleteAsync(reviewId);
    }
    
}