namespace ShopStats.DTOs;

public class ShopWithSalesDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;

    public List<SaleInfoDto> Sales { get; set; } = new();
}