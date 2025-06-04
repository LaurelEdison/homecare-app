using HomeCareApp.Domain.Entities;

namespace HomeCareApp.Domain.Interfaces;

public interface ICareRequestRepository
{
    CareRequest? GetById(Guid id);
    List<CareRequest> GetAllByEmail(string email);
    List<CareRequest> GetAllUnassigned();
    List<CareRequest> GetAll();
    string Add(CareRequest request);
    string Update(CareRequest request);
    string Delete(Guid id);
}