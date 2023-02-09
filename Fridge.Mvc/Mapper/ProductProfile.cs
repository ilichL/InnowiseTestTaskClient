using AutoMapper;
using FridgeWarehouse.Core.DTOs;
using FridgeWarehouse.Mvc.Models.ViewModels;

namespace FridgeWarehouse.Mvc.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDTO, ProductViewModel>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(product => product.Id))
                .ForMember(dto => dto.Name,
                    opt => opt.MapFrom(product => product.Name))
                .ForMember(dto => dto.DefaultQuantity,
                    opt => opt.MapFrom(product => product.DefaultQuantity))
                .ForMember(dto => dto.FridgeProduct,
                    opt => opt.MapFrom(product => product.FridgeProduct));



            CreateMap<ProductViewModel, ProductDTO>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(product => product.Id))
                .ForMember(dto => dto.Name,
                    opt => opt.MapFrom(product => product.Name))
                .ForMember(dto => dto.DefaultQuantity,
                    opt => opt.MapFrom(product => product.DefaultQuantity))
                .ForMember(dto => dto.FridgeProduct,
                    opt => opt.MapFrom(product => product.FridgeProduct));


        }
    }
}
