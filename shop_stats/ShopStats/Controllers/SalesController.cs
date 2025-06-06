using Microsoft.AspNetCore.Mvc;
using ShopStats.Models;
using ShopStats.Services;

namespace ShopStats.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SalesController(ISaleService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Sale sale)
    {
        await service.CreateSaleAsync(sale);
        return Ok();
    }
}
