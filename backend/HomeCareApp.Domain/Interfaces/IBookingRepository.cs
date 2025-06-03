using HomeCareApp.Domain.Entities;

namespace HomeCareApp.Domain.Interfaces;

public interface IBookingRepository
{
    List<Booking> GetByProviderId(Guid providerId);
    List<Booking> GetByClientId(Guid clientId);
    string Add(Booking booking);
    string Update(Booking booking);
    Booking? GetById(Guid id);
    List<Booking> GetAll();
    string Delete(Guid bookingId);
}