using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Common;
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
            //Console.WriteLine($"fromId: {model.fromId}, fromCode: {model.fromCode}, toId: {model.toId}, toCode: {model.toCode}");

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            
            var jsonQuery = JsonConvert.SerializeObject(new
			{
				searchFlightCriteria = new
                {
                    fromId = model.departureAirportCode,
                    toId = model.arrivalAirportCode,
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

                var viewModel = new FlightViewModel
                {
                    SearchFlightCriteria = model,
                    SearchFlightResponse = searchFlightResponse
                };

                return View("SearchFlights", viewModel);
            }
			return StatusCode((int)response.StatusCode, response.ReasonPhrase);
		}

        [HttpGet]
		public IActionResult GetFlightDetails()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> GetFlightResults(GetFlightDetailsModel model) 
		{
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jsonQuery = JsonConvert.SerializeObject(new
            {
                getDetailsOfSelectedFlight = new
                {
                    token = model.token,
                    currency_code = model.currency_code
                }
            });
            var content = new StringContent(jsonQuery, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsync("https://localhost:7071/api/Flights/GetDetails", content);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var getFlightDetails = JsonConvert.DeserializeObject<GetFlightDetailsResponseModel>(responseData);
                return View("GetFlightDetails", getFlightDetails);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

        [HttpGet]
        public async Task<IActionResult> SearchAirports([FromQuery] string term)
        {
            try
            {   
                var client = _httpClientFactory.CreateClient();
                var encodedTerm = Uri.EscapeDataString(term ?? string.Empty);
                var response = await client.GetAsync($"https://localhost:7071/api/Airports?term={encodedTerm}");

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                   
                    var jsonResponse = JObject.Parse(responseData);

                    var results = jsonResponse["results"].ToObject<List<AirportSearchResponseModel>>();                

                    return Ok(new { results });
                }                                
                return StatusCode((int)response.StatusCode, new { results = new List<object>() });
            }
            catch (Exception ex)
            {                
                return StatusCode(500, new { results = new List<object>() });
            }
        }

        [HttpGet]
        public IActionResult CheckoutFlights(string token, decimal totalPrice, string airlineName, int flightNumber, string departureAirportName, string arrivalAirportName)
        {
            var viewModel = new FlightViewModel
            {
                GetFlightDetailsResponse = new GetFlightDetailsResponseModel
                {
                    Token = token,
                    TotalPrice = totalPrice,
                    AirlineName = airlineName,
                    FlightNumber = flightNumber,
                    DepartureAirportName = departureAirportName,
                    ArrivalAirportName = arrivalAirportName
                }
            };
            return View(viewModel);
        }
    }
}