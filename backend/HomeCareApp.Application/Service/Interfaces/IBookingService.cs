using HomeCareApp.Application.Dto;
using HomeCareApp.Domain.Entities;

namespace HomeCareApp.Application.Service.Implementations;

public interface IBookingService
{
    List<Booking> GetByClientId(Guid clientId);
    List<Booking> GetByProviderId(Guid providerId);
    List<Booking> GetAll();
    string Create(CreateBookingDto dto);
    string Delete(Guid bookingId);
}