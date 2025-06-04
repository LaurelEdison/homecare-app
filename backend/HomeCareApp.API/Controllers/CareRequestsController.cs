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


    [HttpGet("client/{email}")]
    public IActionResult Get(string email)
    {
        var response = _service.GetAllByEmail(email);
        return Ok(response);
    }
    public CareRequestsController(CareRequestService service)
    {
        _service = service;
    }

    [HttpPost("create")]
    public IActionResult Create([FromBody] CreateCareRequestDto dto)
    {
        var request = _service.CreateCareRequest(dto);
        return Ok(request);
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

    [HttpGet("unassigned")]
    public IActionResult Unassigned()
    {
        var response = _service.GetAllUnassigned();
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetId(Guid id)
    {
        var request = _service.GetById(id);
        return Ok(request);
    }

    [HttpPost("delete/{id:guid}")]
    public IActionResult DeleteCareRequest(Guid id)
    {
        var success = _service.Delete(id);
        return Ok(success);
    }
    
    
}