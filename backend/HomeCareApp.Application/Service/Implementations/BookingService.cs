using HomeCareApp.Application.Dto;
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

    public string Create(CreateBookingDto dto)
    {
        var booking = Booking.Create(Guid.NewGuid(), dto.RequestId, dto.ProviderId, dto.RequestedDate);
        booking.Status = dto.Status;
        
        return _repository.Add(booking);
    }
    public string Delete(Guid bookingId)
    {
        return _repository.Delete(bookingId);
    }

    public List<Booking> GetByProviderIdS(Guid providerId)
    {
        return _repository.GetByProviderId(providerId);
    }

    public string DeleteCompletedBookings()
    {
        return _repository.DeleteOnComplete();
    }


}