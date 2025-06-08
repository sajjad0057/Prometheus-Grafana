using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopMetrics.API.DTOs;
using ShopMetrics.API.Services;

namespace ShopMetrics.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly MetricsService _metrics;

    public OrderController(MetricsService metrics)
    {
        _metrics = metrics;
    }

    [HttpPost("place")]
    public IActionResult PlaceOrder([FromBody] OrderDto dto)
    {
        // Order processing logic would go here

        _metrics.TrackOrder(dto.ShopId.ToString());
        return Ok();
    }
}