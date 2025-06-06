using Microsoft.EntityFrameworkCore;
using ShopStats.Models;

namespace ShopStats.Contexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Shop> Shops => Set<Shop>();
    public DbSet<Sale> Sales => Set<Sale>();
}

