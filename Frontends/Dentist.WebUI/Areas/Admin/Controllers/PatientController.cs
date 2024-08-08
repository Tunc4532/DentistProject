using Dentist.Dtos.PatientDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dentist.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Patient")]
    public class PatientController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<PatientController> _logger;

        public PatientController(IHttpClientFactory httpClientFactory, ILogger<PatientController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        [HttpGet]
        [Route("PatientList")]
        public async Task<IActionResult> PatientList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7119/api/Patients");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPatientDto>>(jsonData);
                return View(values);
            }
            _logger.LogError("Null reference exception occurred in PatientList method.");

            return View();
        }
    }
}
