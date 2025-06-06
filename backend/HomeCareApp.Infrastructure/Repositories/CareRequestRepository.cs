using HomeCareApp.Domain.Entities;
using HomeCareApp.Domain.Interfaces;
using HomeCareApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HomeCareApp.Infrastructure.Repositories;

public class CareRequestRepository : ICareRequestRepository
{
    private readonly AppDbContext  _context;
    public CareRequestRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public CareRequest? GetById(Guid id)
    {
        return _context.CareRequests.Find(id);
    }
    public List<CareRequest> GetAllByEmail(string email)
    {
        return _context.CareRequests.Where(x => x.Client.Email == email).ToList();
    }

    public List<CareRequest> GetAllUnassigned()
    {
        var assignedRequestIds= _context.Bookings.Select(x => x.RequestId).Distinct().ToHashSet().ToList();
        var unassignedRequests = _context.CareRequests
            .Where(cr => !assignedRequestIds.Contains(cr.Id))
            .ToList();
        return unassignedRequests;
    }
    
    public List<CareRequest> GetAll()
    {
        return _context.CareRequests.ToList();
    }
    public string Add(CareRequest request)
    {
        _context.CareRequests.Add(request);
        _context.SaveChanges();
        
        return "Successfully added Care request";
    }
    public string Update(CareRequest request)
    {
        _context.CareRequests.Update(request);
        _context.SaveChanges();
        return "Successfully updated Care request";
    }
    public string Delete(Guid id)
    {
        var  request = _context.CareRequests.Find(id);
        if (request != null)
        {
            _context.CareRequests.Remove(request);
            _context.SaveChanges();
            return "Successfully deleted Care Request";
        }

        return "Could not find care request";
    }
}