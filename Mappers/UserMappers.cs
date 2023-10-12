using AutoMapper;
using CrudDTOS.DTOs;
using CrudDTOS.Model;

namespace CrudDTOS.Mappers
{
    public class UserMappers : Profile
    {
        public UserMappers()
        {
            CreateMap<UserModel, UserDto>();
            CreateMap<UserModel, UserDetailsDto>();
            CreateMap<UserDetailsDto, UserModel>();
        }
    }
}