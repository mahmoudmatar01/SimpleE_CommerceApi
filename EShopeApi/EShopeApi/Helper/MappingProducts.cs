using AutoMapper;
using EShopeApi.DTO;
using EShopeApi.Models;

namespace EShopeApi.Helper
{
    public class MappingProducts:Profile
    {

        public MappingProducts() { 
                
            CreateMap<Products,ProductDto>();
        
        }

    }
}
