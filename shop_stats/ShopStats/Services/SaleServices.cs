using ShopStats.Contexts;
using ShopStats.Metrics;
using ShopStats.Models;

namespace ShopStats.Services;
public class SaleService(AppDbContext context) : ISaleService
{
    public async Task CreateSaleAsync(Sale sale)
    {
        sale.SaleDate = DateTime.UtcNow;
        context.Sales.Add(sale);
        await context.SaveChangesAsync();

        SaleMetrics.SalesCreated.Inc();
    }
}
