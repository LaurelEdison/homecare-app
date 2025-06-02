using HomeCareApp.Domain.Entities;

namespace HomeCareApp.Application.Service.Implementations;

public interface ICareRequestService
{
    Task<CareRequest> CreateCareRequest(Guid clientId, DateTime requestedDate, string address, string notes, int serviceTypes);
    Task<List<CareRequest>> GetAllByClientIdAsync(Guid clientId);
    Task DeleteAsync(Guid id);
}