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
    
    public async Task<Review?> GetByIdAsync(Guid id)
    {
        return await _context.Reviews.FindAsync(id);
    }

    public async Task<IEnumerable<Review?>> GetAllAsync()
    {
        return await _context.Reviews.ToListAsync();
    }

    public async Task<IEnumerable<Review?>> GetAllByBookingIdAsync(Guid bookingId)
    {
        return await _context.Reviews.Where(r => r.BookingId == bookingId).ToListAsync();
    }

    public async Task AddAsync(Review review)
    {
        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Review review)
    {
        _context.Reviews.Update(review);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var  review = await _context.Reviews.FindAsync(id);
        if (review != null)
        {
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
        }
    }
}