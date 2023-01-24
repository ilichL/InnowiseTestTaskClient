using FridgeWarehouse.Mvc.Models.CreateModels;

namespace FridgeWarehouse.Mvc.Models.ViewModels
{
    public class FridgeCreateModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string LocationAddress { get; set; }
        public Guid FridgeModelId { get; set; }
        public virtual FridgeModelCreateModel FridgeModel { get; set; }
        public virtual ICollection<FridgeProductCreateModel> FridgeProducts { get; set; }
    }
}
