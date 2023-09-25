using AutoMapper;
using eShop.Modules.ProductCatalog;
using eShop.Modules.ShoppingCart;

namespace eShop
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cart, CartQueryItem>();
            CreateMap<Cart, CartDetails>();
            CreateMap<CartItem, CartItemDetails>();
        }
    }
}
