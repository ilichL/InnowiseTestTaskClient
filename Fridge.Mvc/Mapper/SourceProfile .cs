
using AutoMapper;
using FridgeWarehouse.Core.DTOs;
using FridgeWarehouse.Data.Entities;

namespace FridgeWarehouse.Mvc.Mapper
{
    public class SourceProfile : Profile
    {
        public SourceProfile()
        {
            IMapper mapper;
            CreateMap<Fridge, FridgeDTO>()
                .ForMember(dto => dto.Name,
                    opt => opt.MapFrom(fridge => fridge.Name))
                .ForMember(dto => dto.LocationAddress,
                    opt => opt.MapFrom(fridge => fridge.LocationAddress))
                .ForMember(dto => dto.FridgeModelId,
                    opt => opt.MapFrom(fridge => fridge.FridgeModelId))
                //.ForMember(dto => mapper.)
                .ForMember(dto => dto.FridgeProducts,
                    opt => mapper.Map<ProductDTO>(opt));
        }
    }
}
