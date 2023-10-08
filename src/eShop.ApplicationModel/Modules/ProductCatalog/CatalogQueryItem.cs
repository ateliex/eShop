using System.ComponentModel.DataAnnotations;

namespace eShop.Modules.ProductCatalog;

public class CatalogQueryItem
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

    [Display(Name = "Brand Name")]
    public string? BrandName { get; set; }

    [Display(Name = "Category")]
    public int? CategoryId { get; set; }

    [Display(Name = "Category Name")]
    public string? CategoryName { get; set; }

    [Display(Name = "Size")]
    public string? Size { get; set; }

    [Display(Name = "Color")]
    public Color? Color { get; set; }

    [Display(Name = "Features")]
    public string[]? Features { get; set; }

    [Display(Name = "Model")]
    public int? ModelId { get; set; }
}
