using AutoMapper;
using Market.DAL.Models;
using Market.ViewModels;

namespace Market.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterViewModel, AspNetUsers>();
            CreateMap<EditProductViewModel,Product>();

            CreateMap<DetailsAccountViewModel, AspNetUsers>();
            CreateMap<AspNetUsers, DetailsAccountViewModel>();

            CreateMap<EditAccountViewModel, AspNetUsers>();
            CreateMap<AspNetUsers, EditAccountViewModel>();

            CreateMap<EditProductViewModel, Product>();
            CreateMap<Product, EditProductViewModel>();

            CreateMap<CreateProductViewModel, Product>();
            CreateMap<Product, CreateProductViewModel>();
        }
    }
}
