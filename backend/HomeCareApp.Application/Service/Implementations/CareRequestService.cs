using HomeCareApp.Application.Dto;
using HomeCareApp.Domain.Entities;
using HomeCareApp.Domain.Enums;
using HomeCareApp.Domain.Interfaces;

namespace HomeCareApp.Application.Service.Implementations;

public class CareRequestService : ICareRequestService
{
    private readonly ICareRequestRepository _repository;
    private readonly IUserRepository _userRepository;

    public CareRequestService(ICareRequestRepository repository, IUserRepository userRepository)
    {
        _repository = repository;
        _userRepository = userRepository;
    }

    public CareRequest? GetById(Guid id)
    {
        return _repository.GetById(id);
    }

    public string CreateCareRequest(CreateCareRequestDto dto)
    {
        var user = _userRepository.GetByEmail(dto.ClientEmail);

        if (user == null)
        {
            return "User not found";
        }
        var requestedDate = dto.RequestedDate.Kind == DateTimeKind.Unspecified
            ? DateTime.SpecifyKind(dto.RequestedDate, DateTimeKind.Utc)
            : dto.RequestedDate.ToUniversalTime();
        var request = CareRequest.Create(Guid.NewGuid(), user.Id, requestedDate, dto.Address);
        request.Notes = dto.Notes;
        request.ServiceType = dto.ServiceType;
        return _repository.Add(request);
    }

    public List<CareRequest> GetAllByEmail(string email) 
    {
        return _repository.GetAllByEmail(email);
    }

    public string Delete(Guid id)
    {
        return _repository.Delete(id);
    }

    public List<CareRequest> GetAllUnassigned()
    {
        return _repository.GetAllUnassigned();
    }
    
}