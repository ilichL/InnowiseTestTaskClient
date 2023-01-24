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
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.ComponentModel;

namespace FridgeWarehouse.Mvc.Controllers
{
    public class FridgeController : Controller
    {
        private readonly IConfiguration configuration;
        private String Urle;
        private readonly IJsonSerializeService<FridgeDTO> jsonSerializeService;
        private readonly IHttpClientFactory clientFactory;
        private readonly IMapper mapper;
        private readonly ILogger<FridgeController> logger;

        public FridgeController(IHttpClientFactory clientFactory, IConfiguration configuration,
            IJsonSerializeService<FridgeDTO> jsonSerializeService, ILogger<FridgeController> logger,
            IMapper mapper)
        {
            this.configuration = configuration;
            Urle = configuration["ConnectionUrl:FridgeUrl"];

            this.jsonSerializeService = jsonSerializeService;
            this.clientFactory = clientFactory;
            this.logger = logger;
            this.mapper = mapper;
        }




        [HttpGet]
        public IActionResult RemoveFridge()//Guid id
        {
            var model = new DeleteModel()/* { Id = id }*/;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFridge(DeleteModel model)
        {//https://localhost:7225;http://localhost:5225
            using var httpClient = clientFactory.CreateClient("defaultFactory");
            var response = await httpClient.GetAsync("https://localhost:7225/api/Fridge/GetFridgeCollection");
            var responseStr = await response.Content.ReadAsStringAsync();

            var deserialized = JsonConvert.DeserializeObject<Fridge>(responseStr);
            //return Ok(deserialized);
            return View(deserialized);
        }

        public async Task<IActionResult> Tester()
        {
            //await jsonSerializeService.
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFridges()
        {
            Urle += "/GetFridgeCollection";
            var deserialized =
                await jsonSerializeService.ResponseAsync(Urle);
            var models = mapper.Map<List<FridgeViewModel>>((deserialized));

            foreach (var deserialize in deserialized)
            {
                foreach (var model in models)
                {
                    model.FridgeProducts = mapper.Map<ICollection<FridgeProductViewModel>>(deserialize.FridgeProducts);
                }

            }

            return View(models);
        }

        [HttpPost]
        public IActionResult GetFridge()
        {
            return Ok();   
        }


        [HttpGet]
        public async Task<IActionResult> GetFridge(FridgeCreateModel modeler)
        {
            var model = new FridgeCreateModel();
            model.Name = "LOL";
            model.LocationAddress = "LOLER";

            using var httpClient = clientFactory.CreateClient("defaultFactory");

            var response = await httpClient.GetAsync("https://localhost:7225/api/Fridge/AddFridge/");
            var responsestring = await response.Content.ReadAsStringAsync();
            var deserialized = JsonConvert.DeserializeObject<FridgeDTO>(responsestring);
            return Ok(deserialized);
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
