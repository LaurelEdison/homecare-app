using HomeCareApp.Domain.Entities;
using HomeCareApp.Domain.Enums;
using HomeCareApp.Domain.Interfaces;

namespace HomeCareApp.Application.Service.Implementations;

public class CareRequestService : ICareRequestService
{
    private readonly ICareRequestRepository _repository;

    public CareRequestService(ICareRequestRepository repository)
    {
        _repository = repository;
    }

    public string CreateCareRequest(Guid clientId, DateTime requestedDate, string address, string notes, int serviceTypes)
    {
        var request = CareRequest.Create(Guid.NewGuid(), clientId, requestedDate, address);
        request.Notes = notes;
        request.ServiceType = (ServiceTypes)serviceTypes;
        return _repository.Add(request);
    }

    public List<CareRequest> GetAllByClientIdAsync(Guid clientId)
    {
        return _repository.GetAllByClientId(clientId);
    }

    public string DeleteAsync(Guid id)
    {
        return _repository.Delete(id);
    }
    
}