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
using Microsoft.Extensions.Logging;

namespace FridgeWarehouse.Mvc.Controllers
{
    public class FridgeController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly String fridgeUrle;
        private readonly IJsonSerializeService<FridgeDTO> jsonSerializeService;
        private readonly IHttpClientFactory clientFactory;
        private readonly IMapper mapper;
        private readonly ILogger<FridgeController> logger;

        public FridgeController(IHttpClientFactory clientFactory, IConfiguration configuration,
            IJsonSerializeService<FridgeDTO> jsonSerializeService, ILogger<FridgeController> logger,
            IMapper mapper)
        {
            this.configuration = configuration;
            fridgeUrle = configuration["ConnectionUrl:FridgeUrl"];
            this.jsonSerializeService = jsonSerializeService;
            this.clientFactory = clientFactory;
            this.logger = logger;
            this.mapper = mapper;
        }


        [HttpGet]
        public IActionResult RemoveFridge(Guid id)
        {
            var model = new DeleteModel() { Id = id };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFridge(DeleteModel model)
        {
            try
            {
                string _fridgeUrle = fridgeUrle + "/RemoveFridgeById";
                await jsonSerializeService.ResponseWithIdASync(_fridgeUrle, model.Id);
                return View();
            }
            catch(Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest();
            }

        }


        [HttpGet]
        public async Task<IActionResult> EditFridge(Guid id)
        {
            string _fridgeUrle = fridgeUrle + "/GetFridgeById";
            var fridge = mapper.Map<FridgeViewModel>(
                await jsonSerializeService.ResponseWithIdASync(_fridgeUrle, id));
            return View(fridge);
        }


        [HttpPost]
        public async Task<IActionResult> EditFridge(FridgeViewModel model)
        {
            string _fridgeUrl = fridgeUrle + "EditFridge";
            await jsonSerializeService.PostResponseWithDTOAsync(_fridgeUrl,
                mapper.Map<FridgeDTO>(model));
            return View();
        }


        public async Task<IActionResult> Tester()
        {
            //await jsonSerializeService.
            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> GetAllFridges()
        {
           string _fridgeUrle = fridgeUrle + "/GetFridgeCollection";
            var deserialized =
                await jsonSerializeService.ResponseAsync(_fridgeUrle);
            var a = deserialized.First();
            var mod = mapper.Map<FridgeViewModel>(a);
            var models = mapper.Map<List<FridgeViewModel>>((deserialized));
            //6f9619ff-8b86-d011-b42d-00c05fc964fc

            return View(models);
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
