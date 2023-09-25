using AutoMapper;
using eShop.Data;
using eShop.Modules.ProductCatalog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eShop.Api.ProductCatalog
{
    [Route("api/productcatalog/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "productcatalog")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        private readonly IMapper _mapper;

        public ProductsController(
            ApplicationDbContext db,
            IMapper mapper)
        {
            _db = db;

            _mapper = mapper;
        }

        [HttpGet(Name = "GetProducts")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product[]))]
        public async Task<IActionResult> GetProducts([FromQuery] GetProductsRequest request)
        {
            var products = await _db.Products
                .AsNoTracking()
                .ToListAsync();

            return Ok(products);
        }

        [HttpPost(Name = "PostProduct")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Product))]
        public async Task<IActionResult> PostProduct(Product product)
        {
            _db.Products.Add(product);

            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _db.Products
                .AsNoTracking()
                .Include(x => x.Brand)
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                throw new ApplicationException();
            }

            return Ok(product);
        }

        [HttpPut("{id:int}", Name = "PutProduct")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            product.Id = id;

            _db.Entry(product).State = EntityState.Modified;

            await _db.SaveChangesAsync();

            return Ok(product);
        }

        [HttpDelete("{id:int}", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _db.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _db.Products.Remove(product);

            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
