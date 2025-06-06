using HomeCareApp.Domain.Entities;

namespace HomeCareApp.Domain.Interfaces;

public interface IReviewRepository
{
    Review GetById(Guid id);
    List<Review> GetAllByBookingId(Guid bookingId);
    string Add(Review review);
    string Update(Review review);
    string Delete(Guid id);
    string ClientNameFromId(Guid id);
}