namespace eShop.Modules.ProductCatalog;

public class Model : Entity
{
    public string Name { get; set; }

    public string? Slogan { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public decimal? Discount { get; set; }

    public string? ImageUri { get; set; }

    public int? BrandId { get; set; }

    public Brand? Brand { get; set; }

    public int? CategoryId { get; set; }

    public Category? Category { get; set; }

    public string[]? Sizes { get; set; }

    public Color[]? Colors { get; set; }

    public string[]? Features { get; set; }

    public ICollection<Product> Products { get; set; }
}
