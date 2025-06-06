using ShopStats.Models;

namespace ShopStats.Services
{
    public interface ISaleService
    {
        Task CreateSaleAsync(Sale sale);
    }
}