using AutoMapper;
using eShop.Modules.ShoppingCart;

namespace eShop.Modules.ProductCatalog
{
    public class ProductCatalogMappingProfile : Profile
    {
        public ProductCatalogMappingProfile()
        {
            CreateMap<Product, CatalogQueryItem>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => (src.Name == null) ? src.Model.Name : src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => (src.Description == null) ? src.Model.Description : src.Description))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => (src.BrandId == null) ? src.Model.Brand.Name : src.Brand.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => (src.CategoryId == null) ? src.Model.Category.Name : src.Category.Name))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Model.Colors.First(x => x.Name == src.Color)))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => (src.Price == null) ? src.Model.Price : src.Price))
                .ForMember(dest => dest.Features, opt => opt.MapFrom(src => src.Model.Features));

            CreateMap<Product, CatalogItem>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => (src.Name == null) ? src.Model.Name : src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => (src.Description == null) ? src.Model.Description : src.Description))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => (src.BrandId == null) ? src.Model.Brand.Name : src.Brand.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => (src.CategoryId == null) ? src.Model.Category.Name : src.Category.Name))
                .ForMember(dest => dest.Sizes, opt => opt.MapFrom(src => src.Model.Sizes))
                .ForMember(dest => dest.Colors, opt => opt.MapFrom(src => src.Model.Colors))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => (src.Price == null) ? src.Model.Price : src.Price))
                .ForMember(dest => dest.Features, opt => opt.MapFrom(src => src.Model.Features));
        }
    }
}
