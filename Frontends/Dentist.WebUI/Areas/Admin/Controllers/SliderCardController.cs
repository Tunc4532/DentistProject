using Dentist.Dtos.SliderCardDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Dentist.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/SliderCard")]
    public class SliderCardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<SliderCardController> _logger;

        public SliderCardController(IHttpClientFactory httpClientFactory, ILogger<SliderCardController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        [HttpGet]
        [Route("SliderCardList")]
        public async Task<IActionResult> SliderCardList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7119/api/SliderCards");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSliderCardDto>>(jsonData);
                return View(values);
            }
            _logger.LogError("Null reference exception occurred in SliderCardList method.");

            return View();
        }

        [HttpGet]
        [Route("CreateSliderCard")]
        public IActionResult CreateSliderCard()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateSliderCard")]
        public async Task<IActionResult> CreateSliderCard(CreateSliderCardDto createSliderCardDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSliderCardDto);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7119/api/SliderCards", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SliderCardList", "SliderCard", new { area = "Admin" });
            }

            return View();
        }


        [HttpGet("RemoveSliderCard")]
        [Route("RemoveSliderCard/{id}")]
        public async Task<IActionResult> RemoveSliderCard(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7119/api/SliderCards/Delete/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SliderCardList", "SliderCard", new { area = "Admin" });
            }

            return View();
        }

        [HttpGet]
        [Route("UpdateSliderCard/{id}")]
        public async Task<IActionResult> UpdateSliderCard(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7119/api/SliderCards/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateSliderCardDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        [Route("UpdateSliderCard/{id}")]
        public async Task<IActionResult> UpdateSliderCard(UpdateSliderCardDto updateSliderCardDto)
        {

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateSliderCardDto);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7119/api/SliderCards/Update", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SliderCardList", "SliderCard", new { area = "Admin" });
            }

            return View();
        }
    }
}
