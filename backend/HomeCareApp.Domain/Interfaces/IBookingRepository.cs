using HomeCareApp.Domain.Entities;

namespace HomeCareApp.Domain.Interfaces;

public interface IBookingRepository
{
    Task<List<Booking>> GetByProviderIdAsync(Guid providerId);
    Task<List<Booking>> GetByClientIdAsync(Guid clientId);
    Task AddAsync(Booking booking);
    Task UpdateAsync(Booking booking);
    Task<Booking?> GetByIdAsync(Guid id);
    Task<List<Booking>> GetAllAsync();
    Task DeleteAsync(Guid bookingId);
}