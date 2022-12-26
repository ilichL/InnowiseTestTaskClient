namespace FridgeWarehouse.Mvc.Models.ViewModels
{
    public class FridgeViewModel
    {
        public string Name { get; set; }
        public string LocationAddress { get; set; }
        public Guid FridgeModelId { get; set; }
        public virtual FridgeModelViewModel FridgeModel { get; set; }
        public virtual ICollection<FridgeProductViewModel> FridgeProducts { get; set; }
    }
}
