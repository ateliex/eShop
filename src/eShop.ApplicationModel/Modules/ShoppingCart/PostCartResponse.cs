namespace eShop.Modules.ShoppingCart;

public class PostCartResponse : Response
{
    public PostCartResponse(Guid correlationId)
        : base(correlationId)
    {

    }

    public CartDetails CartDetails { get; set; }
}
