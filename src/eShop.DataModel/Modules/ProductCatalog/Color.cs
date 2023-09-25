namespace eShop.Modules.ProductCatalog;

public class Color
{
    public string Name { get; set; }
    
    public string RBG { get; set; }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}
