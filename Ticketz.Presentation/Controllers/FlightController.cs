using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Ticketz.Application.DTOs.FlightDto;
using Ticketz.Presentation.Models;

namespace Ticketz.Presentation.Controllers
{
	[AllowAnonymous]
	public class FlightController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public FlightController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public IActionResult SearchFlights()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SearchFlights([FromForm] SearchFlightModel model)
		{

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var jsonQuery = JsonConvert.SerializeObject(new
			{
				searchFlightCriteria = new
                {
                    fromId = model.fromId,
                    toId = model.toId,
                    departDate = model.departDate,
                    adults = model.adults,
                    Sort = model.Sort,
                    cabinClass = model.cabinClass,
                    currency_code = model.currency_code
                }
            });
			var content = new StringContent(jsonQuery, Encoding.UTF8, "application/json");

			var client = _httpClientFactory.CreateClient();
			var response = await client.PostAsync("https://localhost:7071/api/Flights", content);

			if (response.IsSuccessStatusCode)
			{
				var responseData = await response.Content.ReadAsStringAsync();
				var searchFlightResponse = JsonConvert.DeserializeObject<List<SearchFlightResponseModel>>(responseData);
				
				return View("SearchFlights", searchFlightResponse);
            }
			return StatusCode((int)response.StatusCode, response.ReasonPhrase);
		}
	}
}
