using HomeCareApp.Domain.Entities;
using HomeCareApp.Domain.Enums;
using HomeCareApp.Domain.Interfaces;

namespace HomeCareApp.Application.Service.Implementations;

public class CareRequestService
{
    private readonly ICareRequestRepository _repository;

    public CareRequestService(ICareRequestRepository repository)
    {
        _repository = repository;
    }

    public async Task<CareRequest> CreateCareRequest(Guid clientId, DateTime requestedDate, string address, string notes, int serviceTypes)
    {
        var request = CareRequest.Create(Guid.NewGuid(), clientId, requestedDate, address);
        request.Notes = notes;
        request.ServiceType = (ServiceTypes)serviceTypes;
        await _repository.AddAsync(request);
        return request;
    }

    public async Task<List<CareRequest>> GetAllByClientIdAsync(Guid clientId)
    {
        return await _repository.GetAllByClientIdAsync(clientId);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
    
}