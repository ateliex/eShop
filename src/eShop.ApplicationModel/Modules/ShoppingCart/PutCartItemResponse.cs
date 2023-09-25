namespace eShop.Modules.ShoppingCart;

public class PutCartItemResponse : Response
{
    public PutCartItemResponse(Guid correlationId)
        : base(correlationId)
    {

    }

    public CartDetails CartDetails { get; set; }
}
