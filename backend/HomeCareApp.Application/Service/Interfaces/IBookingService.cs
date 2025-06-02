using HomeCareApp.Domain.Entities;

namespace HomeCareApp.Application.Service.Implementations;

public interface IBookingService
{
    Task<List<Booking>> GetByClientId(Guid clientId);
    Task<List<Booking>> GetByProviderId(Guid ProviderId);
    Task<List<Booking>> GetAll();
    Task CreateAsync(Guid clientId, Guid providerId, DateTime requestedDate, string status);
    Task DeleteAsync(Guid bookingId);
}