namespace eShop.Modules.ShoppingCart;

public class DeleteCartItemResponse : Response
{
    public DeleteCartItemResponse(Guid correlationId)
        : base(correlationId)
    {

    }
    
    public CartDetails CartDetails { get; set; }
}
