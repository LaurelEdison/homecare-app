using HomeCareApp.Application.Dto;
using HomeCareApp.Application.Service.Implementations;
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

    [HttpGet("provider/{email}")]
    public IActionResult GetByProviderEmail(string email)
    {
        var bookings = _service.GetByProviderEmail(email);
        return Ok(bookings);
    }

    
    [HttpPost("create")]
    public IActionResult Create([FromBody] CreateBookingDto dto)
    {
        var booking = _service.Create(dto);
        return Ok(booking);
    }

    [HttpGet("deletecompletedbookings")]
    public IActionResult DeleteCompletedBookings()
    {
        var response = _service.DeleteCompletedBookings();
        return Ok(response);
    }
}
