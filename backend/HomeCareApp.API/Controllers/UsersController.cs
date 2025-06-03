using HomeCareApp.Application.Dto;
using HomeCareApp.Application.Service.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace HomeCareApp.API.Controllers;


public class UsersController : ControllerBase
{
    private readonly UserService _service;

    public UsersController(UserService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        var user = _service.GetById(id);
        return Ok(user);
    }

    [HttpGet("{email}")]
    public IActionResult Get(string email)
    {
        var user = _service.GetByEmail(email);
        return Ok(user);
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] CreateUserDto dto)
    {
        var user = _service.CreateUser(dto);
        return Ok(user);
    }
    
    
    
}