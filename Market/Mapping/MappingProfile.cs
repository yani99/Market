using AutoMapper;
using Market.Models;
using Market.ViewModels;

namespace Market.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterViewModel, AspNetUsers>();
            CreateMap<EditProductViewModel,Product>();

            CreateMap<Product, EditProductViewModel>();

            CreateMap<DetailsAccountViewModel, AspNetUsers>();
            CreateMap<AspNetUsers, DetailsAccountViewModel>();

            CreateMap<EditAccountViewModel, AspNetUsers>();
            CreateMap<AspNetUsers, EditAccountViewModel>();
        }
    }
}
