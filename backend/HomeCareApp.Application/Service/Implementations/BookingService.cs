using HomeCareApp.Domain.Entities;
using HomeCareApp.Domain.Interfaces;

namespace HomeCareApp.Application.Service.Implementations;

public class BookingService
{
    private readonly IBookingRepository _repository;

    public BookingService(IBookingRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Booking>> GetByClientId(Guid clientId)
    {
        return await _repository.GetByClientIdAsync(clientId);
    }
     public async Task<List<Booking>> GetByProviderId(Guid ProviderId)
    {
        return await _repository.GetByProviderIdAsync(ProviderId);
    }

    public async Task<List<Booking>> GetAll()
    {
        return await _repository.GetAllAsync();
    }

    public async Task CreateAsync(Guid clientId, Guid providerId, DateTime requestedDate, string status)
    {
        var booking = Booking.Create(Guid.NewGuid(), clientId, providerId, requestedDate);
        booking.Status = status;
        
        await _repository.AddAsync(booking);
    }

    public async Task DeleteAsync(Guid bookingId)
    {
        await _repository.DeleteAsync(bookingId);
    }
    
     
}