using HomeCareApp.Application.Dto;
using HomeCareApp.Application.Service.Implementations;
using HomeCareApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HomeCareApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly BookingService _service;

    public BookingsController(BookingService service)
    {
        _service = service;
    }

    [HttpGet("provider/{prodiverId}")]
    public IActionResult GetProvider(Guid prodiverId)
    {
        var bookings = _service.GetByProviderId(prodiverId);
        return Ok(bookings);
    }

    [HttpGet("client/{clientId}")]
    public IActionResult GetClient(Guid clientId)
    {
        var bookings = _service.GetByClientId(clientId);
        return Ok(bookings);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateBookingDto dto)
    {
        var booking = _service.Create(dto);
        return Ok(booking);
    }

    [HttpDelete("id")]
    public IActionResult Delete(Guid id)
    {
        var booking = _service.Delete(id);
        return Ok(booking);
    }
    
}
