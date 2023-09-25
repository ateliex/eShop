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
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        private readonly IMapper _mapper;

        public CategoriesController(
            ApplicationDbContext db,
            IMapper mapper)
        {
            _db = db;

            _mapper = mapper;
        }

        [HttpGet(Name = "GetCategories")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category[]))]
        public async Task<IActionResult> GetCategories([FromQuery] GetCategoriesRequest request)
        {
            var categories = await _db.Categories
                .AsNoTracking()
                .ToListAsync();

            return Ok(categories);
        }

        [HttpPost(Name = "PostCategory")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Category))]
        public async Task<IActionResult> PostCategory(Category category)
        {
            _db.Categories.Add(category);

            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _db.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                throw new ApplicationException();
            }

            return Ok(category);
        }

        [HttpPut("{id:int}", Name = "PutCategory")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            category.Id = id;

            _db.Entry(category).State = EntityState.Modified;

            await _db.SaveChangesAsync();

            return Ok(category);
        }

        [HttpDelete("{id:int}", Name = "DeleteCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _db.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(category);

            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
