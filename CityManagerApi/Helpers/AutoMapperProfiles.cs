using AutoMapper;
using CityManagerApi.Dtos;
using CityManagerApi.Models;

namespace CityManagerApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<City, CityForListDto>()
                .ForMember(dest => dest.CityImageUrl, option =>
                {
                    option.MapFrom(src => src.CityImages.First(p => p.IsMain).Url);
                });

            CreateMap<CityAddDto, City>().ReverseMap();
            CreateMap<City, CityForDetailDto>().ReverseMap();
            CreateMap<CityImage, CityImageDto>().ReverseMap();
        }
    }
}
