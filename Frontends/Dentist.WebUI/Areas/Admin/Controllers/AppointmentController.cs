using Dentist.Dtos.AppointmentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dentist.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Appointment")]
	public class AppointmentController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ILogger<AppointmentController> _logger;

		public AppointmentController(IHttpClientFactory httpClientFactory, ILogger<AppointmentController> logger)
		{
			_httpClientFactory = httpClientFactory;
			_logger = logger;
		}

		[HttpGet]
		[Route("AppointmentList")]
		public async Task<IActionResult> AppointmentList()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7119/api/Appointments");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultAppointmentDto>>(jsonData);
				return View(values);
			}
			_logger.LogError("Null reference exception occurred in AppointmentList method.");

			return View();
		}
	}
}
