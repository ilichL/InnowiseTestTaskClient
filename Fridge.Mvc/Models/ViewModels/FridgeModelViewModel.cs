﻿using FridgeWarehouse.Core.DTOs;

namespace FridgeWarehouse.Mvc.Models.ViewModels
{
    public class FridgeModelViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int year { get; set; }
        public List<FridgeViewModel> Fridge { get; set; }
    }
}
