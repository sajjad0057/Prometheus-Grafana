using Mapster;
using ShopStats.DTOs;
using ShopStats.Models;

namespace ShopStats;

public static class MappingConfig
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<SaleCreateDto, Sale>.NewConfig();
        TypeAdapterConfig<ShopCreateDto, Shop>.NewConfig();
    }
}