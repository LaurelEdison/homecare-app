using HomeCareApp.Application.Dto;
using HomeCareApp.Domain.Entities;

namespace HomeCareApp.Application.Service.Implementations;

public interface ICareRequestService
{
    string CreateCareRequest(CreateCareRequestDto dto);
    List<CareRequest> GetAllByClientId(Guid clientId);
    string Delete(Guid id);
}