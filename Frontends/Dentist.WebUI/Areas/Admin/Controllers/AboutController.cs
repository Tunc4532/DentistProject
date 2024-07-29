using Dentist.Dtos.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Common;
using System.Text;

namespace Dentist.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/About")]
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<AboutController> _logger;

        public AboutController(IHttpClientFactory httpClientFactory, ILogger<AboutController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        [HttpGet]
        [Route("AboutList")]
        public async Task<IActionResult> AboutList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7119/api/Abouts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            _logger.LogError("Null reference exception occurred in AboutList method.");

            return View();
        }

		[HttpGet]
		[Route("CreateAbout")]
		public IActionResult CreateAbout()
		{
			return View();
		}

		[HttpPost]
		[Route("CreateAbout")]
		public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
		{

				var client = _httpClientFactory.CreateClient();
				var jsonData = JsonConvert.SerializeObject(createAboutDto);
				StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
				var responseMessage = await client.PostAsync("https://localhost:7119/api/Abouts", stringContent);
				if (responseMessage.IsSuccessStatusCode)
				{
					return RedirectToAction("AboutList", "About", new { area = "Admin" });
				}

			return View();
		}


		[HttpGet("RemoveAbout")]
		[Route("RemoveAbout/{id}")]
		public async Task<IActionResult> RemoveAbout(int id)
		{
				var client = _httpClientFactory.CreateClient();
				var responseMessage = await client.GetAsync("https://localhost:7119/api/Abouts/Delete/" + id);
				if (responseMessage.IsSuccessStatusCode)
				{
					return RedirectToAction("AboutList", "About", new { area = "Admin" });
				}
			
			return View();
		}

		[HttpGet]
		[Route("UpdateAbout/{id}")]
		public async Task<IActionResult> UpdateAbout(int id)
		{
				var client = _httpClientFactory.CreateClient();

				var responseMessage = await client.GetAsync($"https://localhost:7119/api/Abouts/{id}");
				if (responseMessage.IsSuccessStatusCode)
				{
					var jsonData = await responseMessage.Content.ReadAsStringAsync();
					var values = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
					return View(values);
				}
			
			return View();
		}

		[HttpPost]
		[Route("UpdateAbout/{id}")]
		public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
		{

				var client = _httpClientFactory.CreateClient();

				var jsonData = JsonConvert.SerializeObject(updateAboutDto);
				StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
				var responseMessage = await client.PostAsync("https://localhost:7119/api/Abouts/Update", stringContent);
				if (responseMessage.IsSuccessStatusCode)
				{
					return RedirectToAction("AboutList", "About", new { area = "Admin" });
				}
			
			return View();
		}

	}
}
