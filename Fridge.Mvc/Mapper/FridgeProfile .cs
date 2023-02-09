
using AutoMapper;
using FridgeWarehouse.Core.DTOs;
using FridgeWarehouse.Data.Entities;
using FridgeWarehouse.Mvc.Models.ViewModels;

namespace FridgeWarehouse.Mvc.Mapper
{
    public class FridgeProfile : Profile
    {
        
        public FridgeProfile()
        {
            CreateMap<FridgeDTO, FridgeViewModel>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(fridge => fridge.Id))
                .ForMember(dto => dto.Name,
                    opt => opt.MapFrom(fridge => fridge.Name))
                .ForMember(dto => dto.LocationAddress,
                    opt => opt.MapFrom(fridge => fridge.LocationAddress))
                .ForMember(dto => dto.FridgeModelId,
                    opt => opt.MapFrom(fridge => fridge.FridgeModelId))
                .ForMember(dto => dto.FridgeModel,
                    opt => opt.MapFrom(fridge => fridge.FridgeModel))
                .ForMember(dto => dto.FridgeProducts,
                    opt => opt.MapFrom(fridge => fridge.FridgeProducts));

            CreateMap<FridgeViewModel, FridgeDTO>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(fridge => fridge.Id))
                .ForMember(dto => dto.Name,
                    opt => opt.MapFrom(fridge => fridge.Name))
                .ForMember(dto => dto.LocationAddress,
                    opt => opt.MapFrom(fridge => fridge.LocationAddress))
                .ForMember(dto => dto.FridgeModelId,
                    opt => opt.MapFrom(fridge => fridge.FridgeModelId))
                .ForMember(dto => dto.FridgeModel,
                    opt => opt.MapFrom(fridge => fridge.FridgeModel))
                .ForMember(dto => dto.FridgeProducts,
                    opt => opt.MapFrom(fridge => fridge.FridgeProducts));
        }
        
    }
}
