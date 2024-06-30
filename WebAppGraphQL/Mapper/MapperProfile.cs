using AutoMapper;
using WebAppGraphQL.Dto;
using WebAppGraphQL.Models;

namespace WebAppGraphQL.Mapper
{
    public class MapperProfile : Profile 
    {
        public MapperProfile() 
        { 
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductGroup, ProductGroupDto>().ReverseMap();
            CreateMap<Storage, StorageDto>().ReverseMap();
        }
    }
}
