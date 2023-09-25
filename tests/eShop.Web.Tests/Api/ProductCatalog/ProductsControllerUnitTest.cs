namespace eShop.Api.ProductCatalog;

public class ProductsControllerUnitTest
{
    private ProductsController _sut;

    [Fact]
    public void Test1()
    {
        _sut = new ProductsController(null, null);

        _sut.PostProduct(null);

    }
}