using AutoMapper;
using EShopeApi.DTO;
using EShopeApi.Models;

namespace EShopeApi.Helper
{
    public class MappingUserRegister:Profile
    {

        public MappingUserRegister()
        {
            CreateMap<UserRegister, userRegisterDto>();
        }
    }
}
