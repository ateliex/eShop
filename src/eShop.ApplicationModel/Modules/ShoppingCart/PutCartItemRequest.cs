using System.ComponentModel.DataAnnotations;

namespace eShop.Modules.ShoppingCart;

public class PutCartItemRequest : Request
{
    public string BuyerId { get; set; }
}
