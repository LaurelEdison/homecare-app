using HomeCareApp.Domain.Entities;

namespace HomeCareApp.Application.Service.Implementations;

public interface IBookingService
{
    List<Booking> GetByClientId(Guid clientId);
    List<Booking> GetByProviderId(Guid ProviderId);
    List<Booking> GetAll();
    string Create(Guid clientId, Guid providerId, DateTime requestedDate, string status);
    string Delete(Guid bookingId);
}