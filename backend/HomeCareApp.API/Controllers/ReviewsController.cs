using HomeCareApp.Application.Dto;
using HomeCareApp.Application.Service.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace HomeCareApp.API.Controllers;

public class ReviewsController : ControllerBase
{
    private readonly ReviewService _service;

    public ReviewsController(ReviewService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult CreateReview([FromBody] CreateReviewDto dto)
    {
        var review = _service.Create(dto);
        return Ok(review);
    }

    [HttpGet("booking/{bookingId}")]
    public IActionResult GetByBooking(Guid bookingId)
    {
        var reviews = _service.GetAllByBookingId(bookingId);
        return reviews != null ? Ok(reviews) : NotFound();
    }
}