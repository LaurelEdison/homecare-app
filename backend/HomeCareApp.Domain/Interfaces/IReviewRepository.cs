using HomeCareApp.Domain.Entities;

namespace HomeCareApp.Domain.Interfaces;

public interface IReviewRepository
{
    Task<Review?> GetByIdAsync(Guid id);
    Task<List<Review>> GetAllByBookingIdAsync(Guid bookingId);
    Task AddAsync(Review review);
    Task UpdateAsync(Review review);
    Task DeleteAsync(Guid id);
}