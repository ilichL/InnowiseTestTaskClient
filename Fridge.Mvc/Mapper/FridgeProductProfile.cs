using AutoMapper;
using FridgeWarehouse.Core.DTOs;
using FridgeWarehouse.Mvc.Models.ViewModels;
using FridsgeWarehouse.Data.Entities;

namespace FridgeWarehouse.Mvc.Mapper
{
    public class FridgeProductProfile : Profile
    {
        public FridgeProductProfile()
        {
            CreateMap<FridgeProductDTO, FridgeProductViewModel>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(product => product.Id))
                .ForMember(dto => dto.Quantity,
                    opt => opt.MapFrom(product => product.Quantity))
                .ForMember(dto => dto.Product,
                    opt => opt.MapFrom(product => product.Product))
                .ForMember(dto => dto.Fridge,
                    opt => opt.MapFrom(product => product.Fridge));

            CreateMap<FridgeProductViewModel, FridgeProductDTO> ()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(product => product.Id))
                .ForMember(dto => dto.Quantity,
                    opt => opt.MapFrom(product => product.Quantity))
                .ForMember(dto => dto.Product,
                    opt => opt.MapFrom(product => product.Product))
                .ForMember(dto => dto.Fridge,
                    opt => opt.MapFrom(product => product.Fridge));
        }


        
    }
}
