using HomeCareApp.Domain.Entities;

namespace HomeCareApp.Domain.Interfaces;

public interface ICareRequestRepository
{
    Task<CareRequest?> GetByIdAsync(Guid id);
    Task<IEnumerable<CareRequest?>> GetAllAsync();
    Task<List<CareRequest>> GetAllByClientIdAsync(Guid clientId);
    Task AddAsync(CareRequest request);
    Task UpdateAsync(CareRequest request);
    Task DeleteAsync(Guid id);
}