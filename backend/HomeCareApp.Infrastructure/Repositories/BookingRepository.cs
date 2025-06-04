using HomeCareApp.Domain.Entities;
using HomeCareApp.Domain.Interfaces;
using HomeCareApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HomeCareApp.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly AppDbContext  _context;

    public BookingRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Booking> GetByProviderId(Guid providerId)
    {
        return _context.Bookings.Where(b => b.ProviderId == providerId).ToList();
    }
    public List<Booking> GetByProviderEmail(string email)
    {
        return _context.Bookings.Where(b => b.Provider.Email== email).ToList();
    }
    public List<Booking> GetByClientId(Guid clientId)
    {
        return _context.Bookings.Where(b => b.MCareRequest.ClientId == clientId).ToList();
    }
    public string Add(Booking booking)
    {
        _context.Bookings.Add(booking);
        _context.SaveChanges();
        return "Successfully added booking";
    }

    public string DeleteOnComplete()
    {
        _context.Bookings.RemoveRange(_context.Bookings.Where(b => b.Status == "Completed"));
        _context.SaveChanges();
        return "Successfully deleted completed booking";
    }

    public string Update(Booking booking)
    {
        _context.Bookings.Update(booking);
        _context.SaveChanges();
        return "Successfully updated booking";
        
    }

    public string Delete(Guid bookingId)
    {
        var booking = _context.Bookings.Find(bookingId);
        if (booking != null)
        {
            _context.Bookings.Remove(booking);
            _context.SaveChanges();
            return "Successfully removed booking";
        }
        return "Could not find bookingId";
    }

    public Booking? GetById(Guid id)
    {
        return _context.Bookings.Find(id);
    }
    public List<Booking> GetAll()
    {
        return _context.Bookings.ToList();
    }
    
}