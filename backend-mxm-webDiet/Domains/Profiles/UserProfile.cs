using AutoMapper;
using mxm_webDiet.Domains.Dto;
using mxm_webDiet.Domains.Models;

namespace mxm_webDiet.Domains.Profiles;

public class UserProfile : Profile
    {
        public UserProfile()
        {      
             CreateMap< UserRequestApiDto, User>();
        }
    }