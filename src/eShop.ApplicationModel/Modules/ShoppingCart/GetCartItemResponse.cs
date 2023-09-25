namespace eShop.Modules.ShoppingCart;

public class GetCartItemResponse : Response
{
    public GetCartItemResponse(Guid correlationId)
        : base(correlationId)
    {

    }

    public CartItemDetails CartItemDetails { get; set; }
}
