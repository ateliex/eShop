namespace eShop.Modules.ShoppingCart;

public class CartDetails
{
    public int Id { get; set; }
    public string BuyerId { get; set; }
    public int TotalQuantity { get; set; }
    public CartItemDetails[] Items { get; set; }   
}
