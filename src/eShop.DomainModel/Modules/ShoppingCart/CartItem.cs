using Ardalis.GuardClauses;

namespace eShop.Modules.ShoppingCart;

public class CartItem
{
    public int CartId { get; private set; }
    public Cart Cart { get; private set; }

    public int ProductId { get; private set; }

    public decimal UnitPrice { get; private set; }

    public int Quantity { get; private set; }

    public CartItem(Cart cart, int productId, decimal unitPrice, int quantity)
    {
        CartId = cart.Id;
        Cart = cart;
        ProductId = productId;
        UnitPrice = unitPrice;
        SetQuantity(quantity);
    }

    public void AddQuantity(int quantity)
    {
        Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);

        Quantity += quantity;
    }

    public void SetQuantity(int quantity)
    {
        Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);

        Quantity = quantity;
    }

    private CartItem()
    {
        
    }
}
