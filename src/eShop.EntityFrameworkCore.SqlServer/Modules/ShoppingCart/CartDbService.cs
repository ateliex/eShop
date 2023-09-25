using eShop.Data;
using Microsoft.EntityFrameworkCore;

namespace eShop.Modules.ShoppingCart;

public class CartDbService : CartRepositoryInterface
{
    private readonly ApplicationDbContext _db;

    public CartDbService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Cart> GetCartById(int id)
    {
        var cart = await _db.Carts
            .Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (cart == null)
        {
            throw new ApplicationException();
        }

        return cart;
    }

    public async Task Add(Cart cart)
    {
        _db.Carts.Add(cart);

        await _db.SaveChangesAsync();
    }

    public async Task Update(Cart cart)
    {
        await _db.SaveChangesAsync();
    }

    public async Task Delete(Cart cart)
    {
        _db.Carts.Remove(cart);

        await _db.SaveChangesAsync();
    }
}
