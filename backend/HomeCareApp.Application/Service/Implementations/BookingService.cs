using HomeCareApp.Application.Dto;
using HomeCareApp.Domain.Entities;
using HomeCareApp.Domain.Interfaces;

namespace HomeCareApp.Application.Service.Implementations;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _repository;
    private readonly ICareRequestRepository _careRequestRepository;

    public BookingService(IBookingRepository repository, ICareRequestRepository careRequestRepository)
    {
        _repository = repository;
        _careRequestRepository = careRequestRepository;
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
        var booking = Booking.Create(Guid.NewGuid(), dto.RequestId, dto.ProviderId);

        var cr = _careRequestRepository.GetById(dto.RequestId);

        if (cr == null)
        {
            return "There is no such care request";
        }
        
        booking.RequestedDate = cr.RequestedDate;
        booking.Status = "Pending";
        
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

    public List<Booking> GetByProviderEmail(string email)
    {
        return _repository.GetByProviderEmail(email);
    }
    public string DeleteCompletedBookings()
    {
        return _repository.DeleteOnComplete();
    }

    public bool UpdateBookingStatus(Guid bookingId, string status)
    {
        
        return _repository.UpdateStatus(bookingId ,status);
    }


}