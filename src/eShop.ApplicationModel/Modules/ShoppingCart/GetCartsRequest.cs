namespace eShop.Modules.ShoppingCart;

public class GetCartsRequest : Request
{
    public int PageSize { get; set; }
    public int PageIndex { get; set; }
}
