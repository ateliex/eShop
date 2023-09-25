namespace eShop.Modules.ShoppingCart;

public class GetCartItemRequest : Request
{
    public int Id { get; set; }

    public int ProductId { get; set; }
}
