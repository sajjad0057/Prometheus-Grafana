using Mapster;
using Microsoft.AspNetCore.Mvc;
using ShopStats.DTOs;
using ShopStats.Models;
using ShopStats.Services;

namespace ShopStats.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SalesController(ISaleService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SaleCreateDto saleDto)
    {
        var sale = saleDto.Adapt<Sale>();
        await service.CreateSaleAsync(sale);
        return Ok();
    }
}
