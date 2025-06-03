using HomeCareApp.Application.Dto;
using HomeCareApp.Application.Service.Implementations;
using HomeCareApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HomeCareApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CareRequestsController : ControllerBase
{
    private readonly CareRequestService _service;

    public CareRequestsController(CareRequestService service)
    {
        _service = service;
    }

    [HttpGet("client/{clientId}")]
    public IActionResult GetClient(Guid clientId)
    {
        var requests = _service.GetAllByClientId(clientId);
        return Ok(requests);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateCareRequestDto dto)
    {
        var newRequest = _service.CreateCareRequest((dto));
        return Ok(newRequest);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var success = _service.Delete(id);
        return Ok(success);
    }
    
}