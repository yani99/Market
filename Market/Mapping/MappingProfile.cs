using AutoMapper;
using Market.Models;
using Market.ViewModels;

namespace Market.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, CreatePostViewModel>();
            CreateMap<RegisterViewModel, AspNetUsers>();
            CreateMap<EditProductViewModel,Product>();
            CreateMap<Product, EditProductViewModel>();

            CreateMap<DetailAccountViewModel, AspNetUsers>();
            CreateMap<AspNetUsers, DetailAccountViewModel>();
        }
    }
}
