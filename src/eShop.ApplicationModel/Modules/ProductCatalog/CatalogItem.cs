using System.ComponentModel.DataAnnotations;

namespace eShop.Modules.ProductCatalog;

public class CatalogItem
{
    public int? Id { get; set; }

    [Display(Name = "Name")]
    public string? Name { get; set; }

    [Display(Name = "Slogan")]
    public string? Slogan { get; set; }

    [Display(Name = "Description")]
    public string? Description { get; set; }

    [Display(Name = "Price")]
    public decimal? Price { get; set; }

    [Display(Name = "Discount")]
    public decimal? Discount { get; set; }

    [Display(Name = "Image")]
    public string? ImageUri { get; set; }

    [Display(Name = "Brand")]
    public int? BrandId { get; set; }

    public string? BrandName { get; set; }

    [Display(Name = "Category")]
    public int? CategoryId { get; set; }

    public string? CategoryName { get; set; }

    [Display(Name = "Sizes")]
    public string[]? Sizes { get; set; }

    [Display(Name = "Size")]
    public string? Size { get; set; }

    [Display(Name = "Colors")]
    public Color[]? Colors { get; set; }

    [Display(Name = "Color")]
    public string? Color { get; set; }

    [Display(Name = "Features")]
    public string[]? Features { get; set; }

    [Display(Name = "Model")]
    public int ModelId { get; set; }

    //public Model Model { get; set; }

    [Display(Name = "Products Image")]
    public string[]? ProductsImageUri { get; set; }
}
