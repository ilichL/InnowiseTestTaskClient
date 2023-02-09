using FridgeWarehouse.Core.DTOs;

namespace FridgeWarehouse.Mvc.Models.ViewModels
{
    public class FridgeProductViewModel
    {
        public Guid Id;
        public int Quantity { get; set; }
        public virtual FridgeViewModel Fridge { get; set; }
        public ProductViewModel Product { get; internal set; }
    }
}
