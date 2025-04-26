using HomeCareApp.Domain.Entities;

namespace HomeCareApp.Domain.Interfaces;

public interface IBookingRepository
{
    Task <Booking> GetByIdAsync(Guid id);
    Task <IEnumerable<Booking>> GetAllAsync();
    Task<IEnumerable<Booking>> GetByUserAsync(Guid userId);
    Task AddAsync(Booking booking);
    Task UpdateAsync(Booking booking);
    Task DeleteAsync(Booking booking);
}