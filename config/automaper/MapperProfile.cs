using AutoMapper;
using WebApplication1.dtos.store;
using WebApplication1.dtos.supplier;
using WebApplication1.models;

namespace WebApplication1.config.automaper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() {
            CreateMap<StoreDto, Store>();
            CreateMap<Supplier, SupplierDto>();
        }
    }
}
