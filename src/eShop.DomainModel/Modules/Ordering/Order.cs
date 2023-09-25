namespace eShop.Modules.Orders;

public class Order : Entity
{
    public DateTimeOffset OrderDate { get; private set; } = DateTimeOffset.Now;

    public Address ShipToAddress { get; private set; }

    public Order(Address shipToAddress)
    {
        ShipToAddress = shipToAddress;
    }

#pragma warning disable CS8618 // Required by Entity Framework
    private Order() { }
}
