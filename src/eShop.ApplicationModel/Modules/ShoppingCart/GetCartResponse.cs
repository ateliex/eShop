namespace eShop.Modules.ShoppingCart;

public class GetCartResponse : Response
{
    public GetCartResponse(Guid correlationId)
        : base(correlationId)
    {

    }

    public CartDetails CartDetails { get; set; }
}
