namespace ShopStats.DTOs;

public class SaleInfoDto
{
    public string ItemName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public DateTime SaleDate { get; set; }
}