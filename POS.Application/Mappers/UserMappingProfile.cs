using AutoMapper;
using POS.Application.Dtos.User.Request;
using POS.Domain.Entities;

namespace POS.Application.Mappers
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserRequestDto, User>();
            CreateMap<TokenRequestDto, User>();
        }
    }
}
