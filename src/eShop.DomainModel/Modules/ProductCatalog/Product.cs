namespace eShop.Modules.ProductCatalog;

public class Product : Entity
{
    public string? Name { get; set; }

    public string? Slogan { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public decimal? Discount { get; set; }

    public string? ImageUri { get; set; }

    public int? BrandId { get; set; }

    public Brand? Brand { get; set; }

    public int? CategoryId { get; set; }

    public Category? Category { get; set; }

    public string? Size { get; set; }

    public string? Color { get; set; }

    public int ModelId { get; set; }

    public Model? Model { get; set; }
}
