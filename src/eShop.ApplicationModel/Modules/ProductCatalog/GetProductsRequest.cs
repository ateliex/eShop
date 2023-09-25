namespace eShop.Modules.ProductCatalog;

public class GetProductsRequest : Request
{
    public int PageSize { get; set; }
    public int PageIndex { get; set; }
    public int? BrandId { get; set; }
}
