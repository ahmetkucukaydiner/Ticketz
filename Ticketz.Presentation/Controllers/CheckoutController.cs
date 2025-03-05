using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Common;
using System.Text;
using Ticketz.Presentation.Models;

namespace Ticketz.Presentation.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CheckoutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index(int airlineId, string airlineName, string departureAirportName, string arrivalAirportName, int flightNumber, DateTime departureTime, DateTime arrivalTime, decimal totalPrice, string luggageDetail, string cabinClass, int departureAirportId, int arrivalAirportId, string brandedFareName, int adultPassengers)
        {
            var viewModel = new CheckoutViewModel
            {
                GetFlightDetailsResponse = new GetFlightDetailsResponseModel
                {
                    AirlineId = airlineId,
                    TotalPrice = totalPrice,
                    AirlineName = airlineName,
                    FlightNumber = flightNumber,
                    DepartureAirportName = departureAirportName,
                    ArrivalAirportName = arrivalAirportName,
                    DepartureTime = departureTime,
                    ArrivalTime = arrivalTime,
                    LuggageDetail = luggageDetail,
                    CabinClass = cabinClass,
                    DepartureAirportId = departureAirportId,
                    ArrivalAirportId = arrivalAirportId,
                    BrandedFareName = brandedFareName,
                    AdultPassengers = adultPassengers
                }
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CheckoutViewModel model)
        {
            var jsonQuery = JsonConvert.SerializeObject(new
            {
                
                airlineId = model.GetFlightDetailsResponse.AirlineId,
                price = model.GetFlightDetailsResponse.TotalPrice,
                customerFirstName = model.CustomerFirstName,
                customerLastName = model.CustomerLastName,
                customerPassportNumber = model.CustomerPassportNumber,
                customerPhoneNumber = model.CustomerPhoneNumber,
                customerEmail = model.CustomerEmail,
                flightNumber = model.GetFlightDetailsResponse.FlightNumber,
                departureTime = model.GetFlightDetailsResponse.DepartureTime,
                arrivalTime = model.GetFlightDetailsResponse.ArrivalTime,
                adultPassengers = model.GetFlightDetailsResponse.AdultPassengers,
                cabinClass = model.GetFlightDetailsResponse.CabinClass,
                brandedFareName = model.GetFlightDetailsResponse.BrandedFareName,
                luggage = model.GetFlightDetailsResponse.LuggageDetail,
                departureAirportId = model.GetFlightDetailsResponse.DepartureAirportId,
                arrivalAirportId = model.GetFlightDetailsResponse.ArrivalAirportId,
                cardNumber = model.CardNumber,
                cardHolderName = model.CardHolderName,
                expirationDate = model.ExpirationDate,
                cvv = model.Cvv
            });

            var content = new StringContent(jsonQuery, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsync("https://localhost:7071/api/Orders", content);

            if(response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var checkoutResponse = JsonConvert.DeserializeObject<CheckoutResponseModel>(responseData);
                return RedirectToAction("Index", "Success", checkoutResponse);
            }

            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }
    }
}
