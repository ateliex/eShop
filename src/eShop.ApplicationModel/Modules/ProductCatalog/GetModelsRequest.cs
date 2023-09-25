namespace eShop.Modules.ProductCatalog;

public class GetModelsRequest : Request
{
    public int PageSize { get; set; }
    public int PageIndex { get; set; }
    public int? BrandId { get; set; }
}
