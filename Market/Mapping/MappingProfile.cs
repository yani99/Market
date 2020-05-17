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
        }
    }
}
