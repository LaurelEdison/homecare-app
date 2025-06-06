using HomeCareApp.Domain.Entities;
using HomeCareApp.Domain.Interfaces;
using HomeCareApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HomeCareApp.Infrastructure.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly AppDbContext  _context;

    public ReviewRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public Review GetById(Guid id)
    {
        return _context.Reviews.Find(id)!;
    }
    public List<Review> GetAllByBookingId(Guid bookingId)
    {
        return _context.Reviews.Where(r => r.BookingId == bookingId).ToList();
    }

    public string Add(Review review)
    {
        _context.Reviews.Add(review);
        _context.SaveChanges();
        return "Successfully added review";
    }

    public string Update(Review review)
    {
        _context.Reviews.Update(review);
        _context.SaveChanges();
        return "Successfully updated review";
    }

    public string Delete(Guid id)
    {
        var  review = _context.Reviews.Find(id);
        if (review != null)
        {
            _context.Reviews.Remove(review);
            _context.SaveChanges();
            return "Successfully deleted review";
        }

        return "Could not find review";
    }

    public string ClientNameFromId(Guid id)
    {
        var user = _context.Reviews.Find(id).Booking.MCareRequest.Client.FullName;
        return user;
    }
    
}