using AutoMapper;
using mxm_webDiet.Domains.Dto;
using mxm_webDiet.Domains.Models;

namespace mxm_webDiet.Domains.Profiles;

public class ChoiceProfile : Profile
    {
        public ChoiceProfile()
        {      
             CreateMap<Choice, ChoiceDTO>()
             .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.text));
        }
    }