using System.ComponentModel.DataAnnotations;

namespace eShop.Modules.ShoppingCart;

public class PutCartRequest : Request
{
    public string BuyerId { get; set; }
}
