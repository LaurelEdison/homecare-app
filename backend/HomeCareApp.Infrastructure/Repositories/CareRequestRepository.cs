using HomeCareApp.Domain.Entities;
using HomeCareApp.Domain.Interfaces;
using HomeCareApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HomeCareApp.Infrastructure.Repositories;

public class CareRequestRepository : ICareRequestRepository
{
    private readonly AppDbContext  _context;

    CareRequestRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<CareRequest?> GetByIdAsync(Guid id)
    {
        return await _context.CareRequests.FindAsync(id);
    }
    public async Task<IEnumerable<CareRequest?>> GetAllByClientIdAsync(Guid clientId)
    {
        return await _context.CareRequests.Where(x => x.ClientId == clientId).ToListAsync();
    }
    public async Task<IEnumerable<CareRequest?>> GetAllAsync()
    {
        return await _context.CareRequests.ToListAsync();
    }
    public async Task AddAsync(CareRequest request)
    {
        await _context.CareRequests.AddAsync(request);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(CareRequest request)
    {
        _context.CareRequests.Update(request);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(Guid id)
    {
        var  request = await _context.CareRequests.FindAsync(id);
        if (request != null)
        {
            _context.CareRequests.Remove(request);
            await _context.SaveChangesAsync();
        }
    }
}