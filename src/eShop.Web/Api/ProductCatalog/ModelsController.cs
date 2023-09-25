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
    public class ModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        private readonly IMapper _mapper;

        public ModelsController(
            ApplicationDbContext db,
            IMapper mapper)
        {
            _db = db;

            _mapper = mapper;
        }

        [HttpGet(Name = "GetModels")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Model[]))]
        public async Task<IActionResult> GetModels([FromQuery] GetModelsRequest request)
        {
            var models = await _db.Models
                .AsNoTracking()
                .ToListAsync();

            return Ok(models);
        }

        [HttpPost(Name = "PostModel")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Model))]
        public async Task<IActionResult> PostModel(Model model)
        {
            _db.Models.Add(model);

            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetModel), new { id = model.Id }, model);
        }

        [HttpGet("{id:int}", Name = "GetModel")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Model))]
        public async Task<IActionResult> GetModel(int id)
        {
            var model = await _db.Models
                .AsNoTracking()
                .Include(x => x.Brand)
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
            {
                throw new ApplicationException();
            }

            return Ok(model);
        }

        [HttpPut("{id:int}", Name = "PutModel")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Model))]
        public async Task<IActionResult> PutModel(int id, Model model)
        {
            model.Id = id;

            _db.Entry(model).State = EntityState.Modified;

            await _db.SaveChangesAsync();

            return Ok(model);
        }

        [HttpDelete("{id:int}", Name = "DeleteModel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteModel(int id)
        {
            var model = await _db.Models.FindAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            _db.Models.Remove(model);

            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
