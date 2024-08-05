using Dentist.Dtos.ServicePromotionDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Dentist.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ServicePromotion")]
    public class ServicePromotionController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ServicePromotionController> _logger;

        public ServicePromotionController(IHttpClientFactory httpClientFactory, ILogger<ServicePromotionController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        [HttpGet]
        [Route("ServicePromotionList")]
        public async Task<IActionResult> ServicePromotionList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7119/api/ServicePromotions");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServicePromotionDto>>(jsonData);
                return View(values);
            }
            _logger.LogError("Null reference exception occurred in ServicePromotionList method.");

            return View();
        }

        [HttpGet]
        [Route("CreateServicePromotion")]
        public IActionResult CreateServicePromotion()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateServicePromotion")]
        public async Task<IActionResult> CreateServicePromotion(CreateServicePromotionDto createServicePromotionDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createServicePromotionDto);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7119/api/ServicePromotions", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ServicePromotionList", "ServicePromotion", new { area = "Admin" });
            }

            return View();
        }


        [HttpGet("RemoveServicePromotion")]
        [Route("RemoveServicePromotion/{id}")]
        public async Task<IActionResult> RemoveServicePromotion(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7119/api/ServicePromotions/Delete/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ServicePromotionList", "ServicePromotion", new { area = "Admin" });
            }

            return View();
        }

        [HttpGet]
        [Route("UpdateServicePromotion/{id}")]
        public async Task<IActionResult> UpdateServicePromotion(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7119/api/ServicePromotions/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateServicePromotionDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        [Route("UpdateServicePromotion/{id}")]
        public async Task<IActionResult> UpdateServicePromotion(UpdateServicePromotionDto updateServicePromotionDto)
        {

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateServicePromotionDto);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7119/api/ServicePromotions/Update", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ServicePromotionList", "ServicePromotion", new { area = "Admin" });
            }

            return View();
        }
    }
}
