namespace ShopStats.Models;

public class Sale
{
    public int Id { get; set; }
    public int ShopId { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public DateTime SaleDate { get; set; }
    public Shop? Shop { get; set; }
}
