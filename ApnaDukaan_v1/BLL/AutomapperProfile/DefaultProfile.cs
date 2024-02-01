using ApnaDukaan_v1.BLL.DTOs;
using ApnaDukaan_v1.DAL.Entities;
using AutoMapper;

namespace ApnaDukaan_v1.BLL.AutomapperProfile
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            CreateMap<ProductRequestDTO, Product>();
            CreateMap<Product, ProductResponseDTO>();
        }
    }
}
