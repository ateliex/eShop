namespace eShop.Modules.ShoppingCart;

public class DeleteCartResponse : Response
{
    public DeleteCartResponse(Guid correlationId)
        : base(correlationId)
    {

    }
    
    public CartDetails CartDetails { get; set; }
}
