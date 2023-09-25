namespace eShop.Modules.ShoppingCart;

public class Cart : Entity
{
    public string BuyerId { get; private set; }

    private readonly List<CartItem> _items = new List<CartItem>();
    public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();

    public int TotalQuantity { get; private set; }

    public Cart(string buyerId)
    {
        BuyerId = buyerId;
    }

    public void AddItem(int productId, decimal unitPrice, int quantity = 1)
    {
        if (Items.Any(i => i.ProductId == productId))
        {
            var existingItem = Items.First(i => i.ProductId == productId);

            existingItem.AddQuantity(quantity);
        }
        else
        {
            _items.Add(new CartItem(this, productId, unitPrice, quantity));
        }

        TotalQuantity += quantity;
    }

    public void RemoveItem(int productId)
    {
        var existingItem = Items.First(i => i.ProductId == productId);

        _items.Remove(existingItem);

        TotalQuantity -= existingItem.Quantity;
    }

    public void RemoveEmptyItems()
    {
        _items.RemoveAll(i => i.Quantity == 0);
    }

    public void SetNewBuyerId(string buyerId)
    {
        BuyerId = buyerId;
    }
}
