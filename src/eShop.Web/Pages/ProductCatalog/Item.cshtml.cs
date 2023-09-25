using AutoMapper;
using eShop.Data;
using eShop.Modules.ProductCatalog;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace eShop.Pages.ProductCatalog;

public class ItemModel : PageModel
{
    private readonly ApplicationDbContext _db;

    private readonly ProductCatalogDbService _productCatalogDbService;

    private readonly IMapper _mapper;

    private readonly ILogger<ItemModel> _logger;

    [Display(Name = "Catalog Item")]
    public CatalogItem Item { get; set; }

    public ItemModel(
        ApplicationDbContext db,
        ProductCatalogDbService productCatalogDbService,
        IMapper mapper,
        ILogger<ItemModel> logger)
    {
        _db = db;

        _productCatalogDbService = productCatalogDbService;
        
        _mapper = mapper;

        _logger = logger;
    }

    public async Task OnGet(int id)
    {
        var catalogItem = await _productCatalogDbService.GetCatalogItem(id);

        Item = catalogItem;
    }
}
