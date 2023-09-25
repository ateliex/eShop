using eShop.Data;
using eShop.Modules.ProductCatalog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace eShop.Pages;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;

    private readonly ProductCatalogDbService _productCatalogDbService;

    private readonly ILogger<IndexModel> _logger;

    public IList<Brand> Brands { get; set; }

    public IList<CatalogItem> Items { get; set; }

    public IndexModel(
        ApplicationDbContext db,
        ProductCatalogDbService productCatalogDbService,
        ILogger<IndexModel> logger)
    {
        _db = db;

        _productCatalogDbService = productCatalogDbService;

        _logger = logger;
    }

    public async Task OnGet()
    {
        var brands = await _db.Brands
            .OrderBy(x => x.Id)
            .Take(3)
            .ToListAsync();

        Brands = brands;

        var items = await _productCatalogDbService.GetCatalogItems();

        Items = items.ToList();
    }
}