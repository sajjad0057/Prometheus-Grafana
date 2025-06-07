using Mapster;
using Microsoft.AspNetCore.Mvc;
using ShopStats.DTOs;
using ShopStats.Models;
using ShopStats.Services;

namespace ShopStats.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShopsController(IShopService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var shops = new List<Shop>{ new Shop(), new Shop() };

            return Ok(shops);
        }
        catch (Exception ex) 
        {
            throw ex;
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var shop = new Shop();
            if (shop == null)
                return NotFound();

            return Ok(shop);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ShopCreateDto shopDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var shop = shopDto.Adapt<Shop>();

            var created = await service.CreateAsync(shop);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}