using HomeCareApp.Domain.Entities;

namespace HomeCareApp.Domain.Interfaces;

public interface IReviewRepository
{
    Task<Review> GetByIdAsync(Guid id);
    Task<IEnumerable<CareRequest>> GetAllAsync();
    Task<IEnumerable<Review>> GetAllByUserIdAsync(Guid userId);
    Task AddAsync(Review review);
    Task UpdateAsync(Review review);
    Task DeleteAsync(Guid id);
}