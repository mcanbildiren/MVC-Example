using AutoMapper;
using WebApp.Models;
using WebApp.Models.ViewModels;

namespace WebApp.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<ProductCreateViewModel, Product>().ReverseMap();
            CreateMap<ProductUpdateViewModel, Product>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}
