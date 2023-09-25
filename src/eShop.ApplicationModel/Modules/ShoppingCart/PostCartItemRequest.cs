using System.ComponentModel.DataAnnotations;

namespace eShop.Modules.ShoppingCart;

public class PostCartItemRequest : Request
{
    public int ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
}
