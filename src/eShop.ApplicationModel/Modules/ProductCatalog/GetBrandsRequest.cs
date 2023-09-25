namespace eShop.Modules.ProductCatalog;

public class GetBrandsRequest : Request
{
    public int PageSize { get; set; }
    public int PageIndex { get; set; }
}
