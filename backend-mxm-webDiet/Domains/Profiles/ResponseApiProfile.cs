using AutoMapper;
using mxm_webDiet.Domains.Dto;
using mxm_webDiet.Domains.Models;


namespace mxm_webDiet.Domains.Profiles;

public class ResponseApiProfile : Profile
{
    public ResponseApiProfile()
    {
        CreateMap<ResponseApiModel, ResponseApiDTO>()
        .ForMember(dest => dest.Choice, opt => opt.MapFrom(src => src.choices != null ? src.choices.FirstOrDefault() : null));
    }
}