using AutoMapper;

namespace WebAPI.Profiles
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Models.ViewModels.Category, Models.Data.Category>();
            CreateMap<Models.ViewModels.Product, Models.Data.Product>();
        }
    }
}
