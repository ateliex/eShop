namespace eShop.Modules.ShoppingCart;

public class PostCartItemResponse : Response
{
    public PostCartItemResponse(Guid correlationId)
        : base(correlationId)
    {

    }

    public CartDetails CartDetails { get; set; }
}
