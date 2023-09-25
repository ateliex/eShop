namespace eShop.Modules.ShoppingCart;

public class PutCartResponse : Response
{
    public PutCartResponse(Guid correlationId)
        : base(correlationId)
    {

    }

    public CartDetails CartDetails { get; set; }
}
