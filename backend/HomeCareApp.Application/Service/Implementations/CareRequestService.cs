using HomeCareApp.Application.Dto;
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

    public string CreateCareRequest(CreateCareRequestDto dto)
    {
        var request = CareRequest.Create(Guid.NewGuid(), dto.ClientId, dto.RequestedDate, dto.Address);
        request.Notes = dto.Notes;
        request.ServiceType = dto.ServiceType;
        return _repository.Add(request);
    }

    public List<CareRequest> GetAllByClientId(Guid clientId)
    {
        return _repository.GetAllByClientId(clientId);
    }

    public string Delete(Guid id)
    {
        return _repository.Delete(id);
    }
    
}