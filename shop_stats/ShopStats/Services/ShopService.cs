using Microsoft.EntityFrameworkCore;
using ShopStats.Contexts;
using ShopStats.Models;

namespace ShopStats.Services;

public class ShopService(AppDbContext context) : IShopService
{
    public async Task<List<Shop>> GetAllAsync()
    {
        return await context.Shops
            .Include(s => s.Sales)
            .ToListAsync();
    }

    public async Task<Shop?> GetByIdAsync(int id)
    {
        return await context.Shops
            .Include(s => s.Sales)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Shop> CreateAsync(Shop shop)
    {
        //context.Shops.Add(shop);
        //await context.SaveChangesAsync();
        return shop;
    }
}

