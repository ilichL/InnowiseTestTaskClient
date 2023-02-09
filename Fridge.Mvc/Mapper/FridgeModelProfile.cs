using AutoMapper;
using FridgeWarehouse.Core.DTOs;
using FridgeWarehouse.Mvc.Models.ViewModels;
using FridsgeWarehouse.Data.Entities;

namespace FridgeWarehouse.Mvc.Mapper
{
    public class FridgeModelProfile : Profile
    {
        public FridgeModelProfile()
        {
            CreateMap<FridgeModelDTO, FridgeModelViewModel>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.Name,
                    opt => opt.MapFrom(model => model.Name))
                .ForMember(dto => dto.year,
                    opt => opt.MapFrom(model => model.year))
                .ForMember(dto => dto.Fridge,
                    opt => opt.MapFrom(model => model.Fridge));

            CreateMap<FridgeModelViewModel, FridgeModelDTO>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(model => model.Id))
                .ForMember(dto => dto.Name,
                    opt => opt.MapFrom(model => model.Name))
                .ForMember(dto => dto.year,
                    opt => opt.MapFrom(model => model.year))
                .ForMember(dto => dto.Fridge,
                    opt => opt.MapFrom(model => model.Fridge));
        }
    }
}
