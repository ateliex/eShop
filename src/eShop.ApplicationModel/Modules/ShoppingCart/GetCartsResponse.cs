namespace eShop.Modules.ShoppingCart;

public class GetCartsResponse : Response
{
    public GetCartsResponse(Guid correlationId)
        : base(correlationId)
    {

    }

    public CartQueryItem[] CartQueryItems { get; set; }
}
