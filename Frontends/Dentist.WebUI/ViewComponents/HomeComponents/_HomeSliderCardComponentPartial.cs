using Dentist.Dtos.SliderCardDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dentist.WebUI.ViewComponents.HomeComponents
{
	public class _HomeSliderCardComponentPartial : ViewComponent
	{
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<_HomeSliderCardComponentPartial> _logger;

        public _HomeSliderCardComponentPartial(IHttpClientFactory httpClientFactory, ILogger<_HomeSliderCardComponentPartial> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<IViewComponentResult> InvokeAsync()
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
	}
}
