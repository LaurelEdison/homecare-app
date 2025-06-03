using HomeCareApp.Domain.Entities;

namespace HomeCareApp.Application.Service.Implementations;

public interface ICareRequestService
{
    string CreateCareRequest(Guid clientId, DateTime requestedDate, string address, string notes, int serviceTypes);
    List<CareRequest> GetAllByClientIdAsync(Guid clientId);
    string DeleteAsync(Guid id);
}