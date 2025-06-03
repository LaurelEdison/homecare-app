using HomeCareApp.Domain.Entities;

namespace HomeCareApp.Domain.Interfaces;

public interface ICareRequestRepository
{
    CareRequest? GetById(Guid id);
    List<CareRequest> GetAll();
    List<CareRequest> GetAllByClientId(Guid clientId);
    string Add(CareRequest request);
    string Update(CareRequest request);
    string Delete(Guid id);
}