using HomeCareApp.Domain.Entities;

namespace HomeCareApp.Domain.Interfaces;

public interface IBookingRepository
{
    List<Booking> GetByProviderId(Guid providerId);
    List<Booking> GetByProviderEmail(string email);
    List<Booking> GetByClientId(Guid clientId);
    string Add(Booking booking);
    string DeleteOnComplete();
    string Update(Booking booking);
    string Delete(Guid bookingId);
    Booking? GetById(Guid id);
    List<Booking> GetAll();
}