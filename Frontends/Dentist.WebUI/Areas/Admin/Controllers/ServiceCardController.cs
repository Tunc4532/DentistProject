using Dentist.Dtos.ServiceCardDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Dentist.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ServiceCard")]
    public class ServiceCardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ServiceCardController> _logger;

        public ServiceCardController(IHttpClientFactory httpClientFactory, ILogger<ServiceCardController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        [HttpGet]
        [Route("ServiceCardList")]
        public async Task<IActionResult> ServiceCardList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7119/api/ServiceCards");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceCardDto>>(jsonData);
                return View(values);
            }
            _logger.LogError("Null reference exception occurred in ServiceCardList method.");

            return View();
        }

        [HttpGet]
        [Route("CreateServiceCard")]
        public IActionResult CreateServiceCard()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateServiceCard")]
        public async Task<IActionResult> CreateServiceCard(CreateServiceCardDto createServiceCardDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createServiceCardDto);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7119/api/ServiceCards", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ServiceCardList", "ServiceCard", new { area = "Admin" });
            }

            return View();
        }


        [HttpGet("RemoveServiceCard")]
        [Route("RemoveServiceCard/{id}")]
        public async Task<IActionResult> RemoveServiceCard(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7119/api/ServiceCards/Delete/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ServiceCardList", "ServiceCard", new { area = "Admin" });
            }

            return View();
        }

        [HttpGet]
        [Route("UpdateServiceCard/{id}")]
        public async Task<IActionResult> UpdateServiceCard(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7119/api/ServiceCards/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateServiceCardDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        [Route("UpdateServiceCard/{id}")]
        public async Task<IActionResult> UpdateServiceCard(UpdateServiceCardDto updateServiceCardDto)
        {

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateServiceCardDto);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7119/api/ServiceCards/Update", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ServiceCardList", "ServiceCard", new { area = "Admin" });
            }

            return View();
        }
    }
}
