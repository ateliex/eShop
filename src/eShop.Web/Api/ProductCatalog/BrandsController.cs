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
    public class BrandsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        private readonly IMapper _mapper;

        public BrandsController(
            ApplicationDbContext db,
            IMapper mapper)
        {
            _db = db;

            _mapper = mapper;
        }

        [HttpGet(Name = "GetBrands")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Brand[]))]
        public async Task<IActionResult> GetBrands([FromQuery] GetBrandsRequest request)
        {
            var brands = await _db.Brands
                .AsNoTracking()
                .ToListAsync();

            return Ok(brands);
        }

        [HttpPost(Name = "PostBrand")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Brand))]
        public async Task<IActionResult> PostBrand(Brand brand)
        {
            _db.Brands.Add(brand);

            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBrand), new { id = brand.Id }, brand);
        }

        [HttpGet("{id:int}", Name = "GetBrand")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Brand))]
        public async Task<IActionResult> GetBrand(int id)
        {
            var brand = await _db.Brands
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (brand == null)
            {
                throw new ApplicationException();
            }

            return Ok(brand);
        }

        [HttpPut("{id:int}", Name = "PutBrand")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Brand))]
        public async Task<IActionResult> PutBrand(int id, Brand brand)
        {
            brand.Id = id;

            _db.Entry(brand).State = EntityState.Modified;

            await _db.SaveChangesAsync();

            return Ok(brand);
        }

        [HttpDelete("{id:int}", Name = "DeleteBrand")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var brand = await _db.Brands.FindAsync(id);

            if (brand == null)
            {
                return NotFound();
            }

            _db.Brands.Remove(brand);

            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
