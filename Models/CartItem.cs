namespace MagazinOnline.Models;

public class CartItem
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; } = 1;
    public decimal Total => Price * Quantity;
}
