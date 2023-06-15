using AutoMapper;

namespace WebAPI.Profiles
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Models.ViewModels.CategoryViewModel, Models.Data.Category>().ReverseMap();
            CreateMap<Models.ViewModels.ProductViewModel, Models.Data.Product>().ReverseMap();
        }
    }
}
