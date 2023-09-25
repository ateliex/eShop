namespace eShop.Modules.ShoppingCart;

public interface CartRepositoryInterface
{
    Task<Cart> GetCartById(int id);

    Task Add(Cart product);

    Task Update(Cart product);

    Task Delete(Cart product);
}
