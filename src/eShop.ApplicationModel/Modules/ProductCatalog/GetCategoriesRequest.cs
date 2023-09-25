namespace eShop.Modules.ProductCatalog;

public class GetCategoriesRequest : Request
{
    public int PageSize { get; set; }
    public int PageIndex { get; set; }
}
