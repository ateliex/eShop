using AutoMapper;
using AutoMapper.Features;
using eShop.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Drawing;

namespace eShop.Modules.ProductCatalog;

public class ProductCatalogDbService
{
    private readonly ApplicationDbContext _db;

    private readonly IMapper _mapper;

    public ProductCatalogDbService(
        ApplicationDbContext db,
        IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CatalogQueryItem>> QueryCatalogItems()
    {
        var products = await _db.Products
            .Include(x => x.Category)
            .Include(x => x.Brand)
            .Include(x => x.Model)
                .ThenInclude(x => x.Category)
            .Include(x => x.Model)
                .ThenInclude(x => x.Brand)
            .AsNoTracking()
            .ToListAsync();

        var catalogQueryItems = _mapper.Map<IEnumerable<CatalogQueryItem>>(products);

        return catalogQueryItems;
    }

    public async Task<IEnumerable<CatalogItem>> GetCatalogItems()
    {
        var products = await _db.Products
            .Include(x => x.Category)
            .Include(x => x.Brand)
            .Include(x => x.Model)
                .ThenInclude(x => x.Category)
            .Include(x => x.Model)
                .ThenInclude(x => x.Brand)
            .AsNoTracking()
            .ToListAsync();

        var catalogItems = products
            .GroupBy(x => x.ModelId)
            .Select(g =>
            {
                var firstProduct = g.First();

                var model = firstProduct.Model;

                var catalogItem = new CatalogItem
                {
                    Id = firstProduct.Id,
                    Name = (firstProduct.Name == null ? model.Name : firstProduct.Name),
                    Description = (firstProduct.Description == null ? model.Description : firstProduct.Description),
                    BrandName = (firstProduct.BrandId == null ? model.Brand.Name : firstProduct.Brand.Name),
                    CategoryName = (firstProduct.CategoryId == null ? model.Category.Name : firstProduct.Category.Name),
                    ImageUri = firstProduct.ImageUri,
                    Price = (firstProduct.Price == null ? model.Price : firstProduct.Price),
                    Features = model.Features,
                    Size = firstProduct.Size,
                    Sizes = model.Sizes,
                    Color = firstProduct.Color,
                    Colors = model.Colors,
                    ProductsImageUri = g.Select(x => x.ImageUri).ToArray()
                };

                return catalogItem;
            });

        //var catalogItems = _mapper.Map<IEnumerable<CatalogItem>>(productsByModel);

        return catalogItems;
    }

    public async Task<CatalogItem> GetCatalogItem(int id)
    {
        var product = await _db.Products
            .Include(x => x.Category)
            .Include(x => x.Brand)
            .Include(x => x.Model)
                .ThenInclude(x => x.Category)
            .Include(x => x.Model)
                .ThenInclude(x => x.Brand)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        var productsFromModel = await _db.Products
            .Where(x => x.ModelId == product.ModelId)
            .ToListAsync();

        var model = product.Model;

        var catalogItem = new CatalogItem
        {
            Id = product.Id,
            Name = (product.Name == null ? model.Name : product.Name),
            Description = (product.Description == null ? model.Description : product.Description),
            BrandName = (product.BrandId == null ? model.Brand.Name : product.Brand.Name),
            CategoryName = (product.CategoryId == null ? model.Category.Name : product.Category.Name),
            ImageUri = product.ImageUri,
            Price = (product.Price == null ? model.Price : product.Price),
            Features = model.Features,
            Size = product.Size,
            Sizes = model.Sizes,
            Color = product.Color,
            Colors = model.Colors,
            ProductsImageUri = productsFromModel.Select(x => x.ImageUri).ToArray()
        };

        return catalogItem;
    }
}
