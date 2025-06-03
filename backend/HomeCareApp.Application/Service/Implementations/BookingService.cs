using HomeCareApp.Domain.Entities;
using HomeCareApp.Domain.Interfaces;

namespace HomeCareApp.Application.Service.Implementations;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _repository;

    public BookingService(IBookingRepository repository)
    {
        _repository = repository;
    }

    public List<Booking> GetByClientId(Guid clientId)
    {
        return _repository.GetByClientId(clientId);
    }
     public List<Booking> GetByProviderId(Guid providerId)
    {
        return _repository.GetByProviderId(providerId);
    }

    public List<Booking> GetAll()
    {
        return _repository.GetAll();
    }

    public string Create(Guid clientId, Guid providerId, DateTime requestedDate, string status)
    {
        var booking = Booking.Create(Guid.NewGuid(), clientId, providerId, requestedDate);
        booking.Status = status;
        
        return _repository.Add(booking);
    }
    public string Delete(Guid bookingId)
    {
        return _repository.Delete(bookingId);
    }
    
     
}