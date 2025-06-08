using Microsoft.AspNetCore.Mvc;
using ShopMetrics.API.Services;

namespace ShopMetrics.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShopsController : ControllerBase
{
    private readonly MetricsService _metrics;

    public ShopsController(MetricsService metrics)
    {
        _metrics = metrics;
    }

    [HttpGet("visit")]
    public IActionResult VisitShop([FromQuery] string shopId)
    {
        _metrics.TrackPageView(shopId);
        return Ok("Shop visited");
    }
}