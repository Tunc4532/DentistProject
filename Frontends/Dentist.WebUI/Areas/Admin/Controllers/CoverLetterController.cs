using Dentist.Dtos.CoverLetterDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Dentist.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/CoverLetter")]
    public class CoverLetterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<CoverLetterController> _logger;

        public CoverLetterController(IHttpClientFactory httpClientFactory, ILogger<CoverLetterController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        [HttpGet]
        [Route("CoverLetterList")]
        public async Task<IActionResult> CoverLetterList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7119/api/CoverLetters");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCoverLetterDto>>(jsonData);
                return View(values);
            }
            _logger.LogError("Null reference exception occurred in CoverLetterList method.");

            return View();
        }

        [HttpGet]
        [Route("CreateCoverLetter")]
        public IActionResult CreateCoverLetter()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateCoverLetter")]
        public async Task<IActionResult> CreateCoverLetter(CreateCoverLetterDto createCoverLetterDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCoverLetterDto);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7119/api/CoverLetters", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CoverLetterList", "CoverLetter", new { area = "Admin" });
            }

            return View();
        }


        [HttpGet("RemoveCoverLetter")]
        [Route("RemoveCoverLetter/{id}")]
        public async Task<IActionResult> RemoveCoverLetter(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7119/api/CoverLetters/Delete/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CoverLetterList", "CoverLetter", new { area = "Admin" });
            }

            return View();
        }

        [HttpGet]
        [Route("UpdateCoverLetter/{id}")]
        public async Task<IActionResult> UpdateCoverLetter(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7119/api/CoverLetters/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCoverLetterDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        [Route("UpdateCoverLetter/{id}")]
        public async Task<IActionResult> UpdateCoverLetter(UpdateCoverLetterDto updateCoverLetterDto)
        {

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateCoverLetterDto);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7119/api/CoverLetters/Update", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CoverLetterList", "CoverLetter", new { area = "Admin" });
            }

            return View();
        }


    }
}
