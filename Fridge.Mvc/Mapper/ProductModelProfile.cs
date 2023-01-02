using AutoMapper;
using FridgeWarehouse.Core.DTOs;
using FridsgeWarehouse.Data.Entities;

namespace FridgeWarehouse.Mvc.Mapper
{
    public class ProductModelProfile : Profile
    {
        public ProductModelProfile() => CreateMap<FridgeProduct, FridgeProductDTO>()
                .ForMember(dto => dto.Quantity,
            opt => opt.MapFrom(productModel => productModel.Quantity));

    }
}
