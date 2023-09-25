using AutoMapper;
using eShop.Data;
using eShop.Modules.ShoppingCart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eShop.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "shoppingcart")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        private readonly CartRepositoryInterface _cartRepository;

        private readonly IMapper _mapper;

        public ShoppingCartController(
            ApplicationDbContext db,
            CartRepositoryInterface cartRepository,
            IMapper mapper)
        {
            _db = db;

            _cartRepository = cartRepository;

            _mapper = mapper;
        }

        [HttpGet("carts", Name = "GetCarts")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCartsResponse))]
        public async Task<IActionResult> GetCarts([FromQuery] GetCartsRequest request)
        {
            var carts = await _db.Carts
                .AsNoTracking()
                .ToListAsync();

            var cartQueryItems = _mapper.Map<CartQueryItem[]>(carts);

            var response = new GetCartsResponse(request.GetCorrelationId()) { CartQueryItems = cartQueryItems };

            return Ok(response);
        }

        [HttpPost("carts", Name = "PostCart")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PostCartResponse))]
        public async Task<IActionResult> PostCart(PostCartRequest request)
        {
            var cart = new Cart(request.BuyerId);

            await _cartRepository.Add(cart);

            var cartDetails = _mapper.Map<CartDetails>(cart);

            var response = new PostCartResponse(request.GetCorrelationId()) { CartDetails = cartDetails };

            return CreatedAtAction(nameof(GetCart), new { id = cart.Id }, response);
        }

        [HttpGet("carts/{id:int}", Name = "GetCart")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCartResponse))]
        public async Task<IActionResult> GetCart(int id)
        {
            var request = new GetCartRequest();

            var cart = await _db.Carts
                .AsNoTracking()
                .Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (cart == null)
            {
                return NotFound();
            }

            var cartDetails = _mapper.Map<CartDetails>(cart);

            var response = new PostCartResponse(request.GetCorrelationId()) { CartDetails = cartDetails };

            return Ok(response);
        }

        [HttpPut("carts/{id:int}", Name = "PutCart")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PutCartResponse))]
        public async Task<IActionResult> PutCart(int id, PutCartRequest request)
        {
            var cart = await _cartRepository.GetCartById(id);

            if (cart == null)
            {
                return NotFound();
            }

            cart.SetNewBuyerId(request.BuyerId);

            await _cartRepository.Update(cart);

            var cartDetails = _mapper.Map<CartDetails>(cart);

            var response = new PutCartResponse(request.GetCorrelationId()) { CartDetails = cartDetails };

            return Ok(response);
        }

        [HttpPost("carts/{id:int}/items", Name = "PostCartItem")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostCartItemResponse))]
        public async Task<IActionResult> PostCartItem(int id, PostCartItemRequest request)
        {
            var cart = await _cartRepository.GetCartById(id);

            if (cart == null)
            {
                return NotFound();
            }

            cart.AddItem(request.ProductId, request.UnitPrice, request.Quantity);

            await _cartRepository.Update(cart);

            var cartDetails = _mapper.Map<CartDetails>(cart);

            var response = new PostCartItemResponse(request.GetCorrelationId()) { CartDetails = cartDetails };

            return Ok(response);
        }

        [HttpDelete("carts/{id:int}/items/{productId:int}", Name = "DeleteCartItem")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteCartResponse))]
        public async Task<IActionResult> DeleteCartItem(int id, int productId)
        {
            var request = new DeleteCartItemRequest();

            var cart = await _cartRepository.GetCartById(id);

            if (cart == null)
            {
                return NotFound();
            }

            cart.RemoveItem(productId);

            await _cartRepository.Update(cart);

            var cartDetails = _mapper.Map<CartDetails>(cart);

            var response = new DeleteCartItemResponse(request.GetCorrelationId()) { CartDetails = cartDetails };

            return Ok(response);
        }

        [HttpDelete("carts/{id:int}", Name = "DeleteCart")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteCartResponse))]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var request = new DeleteCartRequest();

            var cart = await _cartRepository.GetCartById(id);

            if (cart == null)
            {
                return NotFound();
            }

            await _cartRepository.Delete(cart);

            var cartDetails = _mapper.Map<CartDetails>(cart);

            var response = new DeleteCartResponse(request.GetCorrelationId()) { CartDetails = cartDetails };

            return Ok(response);
        }
    }
}
