using ShopStats.Models;

namespace ShopStats.Services
{
    public interface IShopService
    {
        Task<Shop> CreateAsync(Shop shop);
        Task<List<Shop>> GetAllAsync();
        Task<Shop?> GetByIdAsync(int id);
    }
}