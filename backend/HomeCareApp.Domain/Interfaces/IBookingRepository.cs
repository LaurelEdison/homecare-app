using HomeCareApp.Domain.Entities;

namespace HomeCareApp.Domain.Interfaces;

public interface IBookingRepository
{
    Task<IEnumerable<Booking>> GetByProviderIdAsync(Guid providerId);
    Task AddAsync(Booking booking);
    Task UpdateAsync(Booking booking);
    Task<Booking?> GetByIdAsync(Guid id);
    Task<IEnumerable<Booking>> GetAllAsync();
    Task DeleteAsync(Guid bookingId);
}