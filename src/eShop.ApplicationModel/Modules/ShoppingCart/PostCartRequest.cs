using System.ComponentModel.DataAnnotations;

namespace eShop.Modules.ShoppingCart;

public class PostCartRequest : Request
{
    public string BuyerId { get; set; }
}
