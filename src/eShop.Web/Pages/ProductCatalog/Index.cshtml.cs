using eShop.Data;
using eShop.Modules.ProductCatalog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace eShop.Pages.ProductCatalog;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;

    private readonly ProductCatalogDbService _productCatalogDbService;

    private readonly ILogger<IndexModel> _logger;

    public IList<CatalogQueryItem> Items { get; set; }

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
        var items = await _productCatalogDbService.QueryCatalogItems();

        Items = items.ToList();
    }
}