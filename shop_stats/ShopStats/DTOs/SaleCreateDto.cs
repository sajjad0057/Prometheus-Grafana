namespace ShopStats.DTOs;

public class SaleCreateDto
{
    public int ShopId { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
