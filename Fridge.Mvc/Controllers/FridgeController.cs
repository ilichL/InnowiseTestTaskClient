 using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System;
using FridgeWarehouse.Mvc.Models.ViewModels;
using FridgeWarehouse.Mvc.Models;
using FridgeWarehouse.Core.Interfaces;
using FridgeWarehouse.Core.DTOs;
using FridgeWarehouse.Data.Entities;
using System.Linq;
using AutoMapper;

namespace FridgeWarehouse.Mvc.Controllers
{
    public class FridgeController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly String Urle;
        private readonly IJsonSerializeService<FridgeDTO> jsonSerialize;
        private readonly IHttpClientFactory clientFactory;
        private readonly IMapper mapper;
        private readonly ILogger<FridgeController> logger;

        public FridgeController(IHttpClientFactory clientFactory, IConfiguration configuration,
            IJsonSerializeService<FridgeDTO> jsonSerialize, ILogger<FridgeController> logger, 
            IMapper mapper)
        {
            this.configuration = configuration;
            Urle = configuration["FridgeUrl"];
            this.jsonSerialize = jsonSerialize;
            this.clientFactory = clientFactory;
            this.logger = logger;
            this.mapper = mapper;
        }




        [HttpGet]
        public IActionResult RemoveFridge()//Guid id
        {
            int id = 0;
            var model = new DeleteModel()/* { Id = id }*/;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFridge(DeleteModel model)
        {//https://localhost:7225;http://localhost:5225
            int i = 0;
            using var httpClient = clientFactory.CreateClient("defaultFactory");
            var response = await httpClient.GetAsync("https://localhost:7225/api/Fridge/GetFridgeCollection");
            var responseStr = await response.Content.ReadAsStringAsync();

            var deserialized = JsonConvert.DeserializeObject<List<Fridge>>(responseStr);
            return Ok(deserialized);
            return View(deserialized);
        }

        public async Task<List<T>> JsonTester(string url)
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetAllFridges()
        {
            using var httpClient = clientFactory.CreateClient("defaultFactory");
            var response = await httpClient.GetAsync("https://localhost:7225/api/Fridge/GetFridgeCollection");
            var responseStr = await response.Content.ReadAsStringAsync();

            var deserialized = mapper.Map<FridgeViewModel>(JsonConvert.DeserializeObject<List<Fridge>>(responseStr));
            return View(deserialized);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
