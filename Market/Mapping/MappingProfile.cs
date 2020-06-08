using AutoMapper;
using Market.DAL.Models;
using Market.ViewModels;

namespace Market.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterViewModel, AspNetUsers>()
            .ReverseMap();

            CreateMap<Product, EditProductViewModel>()
                .ReverseMap();

            CreateMap<AspNetUsers, DetailsAccountViewModel>()
                .ReverseMap();

            CreateMap<AspNetUsers, EditAccountViewModel>()
                .ReverseMap();

            CreateMap<Product, EditProductViewModel>()
                .ReverseMap();

            CreateMap<CreateProductViewModel, Product>()
                .ReverseMap();

            CreateMap<Product, Order>()
              .ForMember(dest => dest.Id, opt => opt.Ignore())
              .ForMember(dest => dest.UserId, opt => opt.Ignore())
              .AfterMap((dest, src) => src.Quantity = 1)
              .AfterMap((dest, src) => src.ShipperId = 1);

            CreateMap<Order, OrderViewModel>();
        }
    }
}
