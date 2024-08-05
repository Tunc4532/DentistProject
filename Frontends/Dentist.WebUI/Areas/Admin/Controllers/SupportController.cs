using Dentist.Dtos.SupportDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Dentist.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Support")]
    public class SupportController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<SupportController> _logger;

        public SupportController(IHttpClientFactory httpClientFactory, ILogger<SupportController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        [HttpGet]
        [Route("SupportList")]
        public async Task<IActionResult> SupportList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7119/api/Supports");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSupportDto>>(jsonData);
                return View(values);
            }
            _logger.LogError("Null reference exception occurred in SupportList method.");

            return View();
        }

        [HttpGet]
        [Route("CreateSupport")]
        public IActionResult CreateSupport()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateSupport")]
        public async Task<IActionResult> CreateSupport(CreateSupportDto createSupportDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSupportDto);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7119/api/Supports", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SupportList", "Support", new { area = "Admin" });
            }

            return View();
        }


        [HttpGet("RemoveSupport")]
        [Route("RemoveSupport/{id}")]
        public async Task<IActionResult> RemoveSupport(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7119/api/Supports/Delete/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SupportList", "Support", new { area = "Admin" });
            }

            return View();
        }

        [HttpGet]
        [Route("UpdateSupport/{id}")]
        public async Task<IActionResult> UpdateSupport(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7119/api/Supports/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateSupportDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        [Route("UpdateSupport/{id}")]
        public async Task<IActionResult> UpdateSupport(UpdateSupportDto updateSupportDto)
        {

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateSupportDto);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7119/api/Supports/Update", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SupportList", "Support", new { area = "Admin" });
            }

            return View();
        }
    }
}
