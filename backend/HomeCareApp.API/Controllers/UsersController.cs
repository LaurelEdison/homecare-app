using HomeCareApp.Application.Dto;
using HomeCareApp.Application.Service.Implementations;
using HomeCareApp.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace HomeCareApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserService _service;

    public UsersController(UserService service)
    {
        _service = service;
    }

    [HttpGet("by-id/{id}")]
    public IActionResult Get(Guid id)
    {
        var user = _service.GetById(id);
        return Ok(user);
    }

    [HttpGet("by-email/{email}")]
    public IActionResult Get(string email)
    {
        var user = _service.GetByEmail(email);
        return Ok(user);
    }

    [HttpGet("by-role/{role}")]
    public IActionResult GetByRole(Roles role)
    {
        var response = _service.GetByRole(role);
        return Ok(response);
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] CreateUserDto dto)
    {
        if (dto == null)
        {
            return BadRequest("Dto is null");
        }
        var user = _service.CreateUser(dto);
        return Ok(user);
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserLoginDto dto)
    {
        if (dto == null)
        {
            return BadRequest("Dto is null");
        }
        var user = _service.Login(dto.email, dto.password);
        if (user == null)
        {
            return Unauthorized(new {message = "Invalid credentials"});
        }

        var response = new UserResponseDto
        {
            Id = user.Id,
            Email = user.Email,
            FullName = user.FullName,
            Role = user.Role,
            
        };
        response.FullName = user.FullName;
        return Ok(response);
    }
    [HttpPost("delete")]
    public IActionResult Delete(UserDeleteDto dto)
    {
        if (dto == null)
        {
            return BadRequest("Dto is null");
        }

        var response = _service.DeleteByEmail(dto.Email);
        return Ok(response);
    }
    
}