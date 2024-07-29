using Dentist.Dtos.AboutDtos;
using Dentist.Dtos.CategoryCardDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Dentist.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/CategoryCard")]
    public class CategoryCardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<CategoryCardController> _logger;

        public CategoryCardController(IHttpClientFactory httpClientFactory, ILogger<CategoryCardController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        [HttpGet]
        [Route("CategoryCardList")]
        public async Task<IActionResult> CategoryCardList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7119/api/CategoryCards");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryCardDto>>(jsonData);
                return View(values);
            }
            _logger.LogError("Null reference exception occurred in AboutList method.");

            return View();
        }

        [HttpGet]
        [Route("CreateCategoryCard")]
        public IActionResult CreateCategoryCard()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateCategoryCard")]
        public async Task<IActionResult> CreateCategoryCard(CreateCategoryCardDto createCategoryCardDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategoryCardDto);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7119/api/CategoryCards", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryCardList", "CategoryCard", new { area = "Admin" });
            }

            return View();
        }


        [HttpGet("RemoveCategoryCard")]
        [Route("RemoveCategoryCard/{id}")]
        public async Task<IActionResult> RemoveCategoryCard(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7119/api/CategoryCards/Delete/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryCardList", "CategoryCard", new { area = "Admin" });
            }

            return View();
        }

        [HttpGet]
        [Route("UpdateCategoryCard/{id}")]
        public async Task<IActionResult> UpdateCategoryCard(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7119/api/CategoryCards/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryCardDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        [Route("UpdateCategoryCard/{id}")]
        public async Task<IActionResult> UpdateCategoryCard(UpdateCategoryCardDto updateCategoryCardDto)
        {

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateCategoryCardDto);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7119/api/CategoryCards/Update", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryCardList", "CategoryCard", new { area = "Admin" });
            }

            return View();
        }
    }
}
