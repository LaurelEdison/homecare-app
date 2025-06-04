using HomeCareApp.Application.Dto;
using HomeCareApp.Domain.Entities;

namespace HomeCareApp.Application.Service.Implementations;

public interface ICareRequestService
{
    CareRequest? GetById(Guid id);
    string CreateCareRequest(CreateCareRequestDto dto);
    List<CareRequest> GetAllByEmail(string email);
    string Delete(Guid id);
    List<CareRequest> GetAllUnassigned();
}