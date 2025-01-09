using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Json;
using Ticketz.Application.DTOs.FlightDto;
using Ticketz.Application.Features.Flights.Queries.SearchFlight;
using Ticketz.Application.Services.FlightService;
using Ticketz.Application.Services.Repositories;
using Ticketz.Domain.Entities;
using Ticketz.Infrastructure.ExternalServices.Helpers;
using Ticketz.Infrastructure.Models.BookingFlightApiModels;
using Airline = Ticketz.Domain.Entities.Airline;

namespace Ticketz.Infrastructure.ExternalServices.BookingFlightApi;

public class BookingFlightService : IFlightService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly IAirlineRepository _airlineRepository;
    private readonly IAirportRepository _airportRepository;

    public BookingFlightService(HttpClient httpClient, IConfiguration configuration, IAirlineRepository airlineRepository, IAirportRepository airportRepository)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _airlineRepository = airlineRepository;
        _airportRepository = airportRepository;
    }

    public async Task<List<SearchFlightQueryResponse>> SearchFlightAsync(FlightSearchCriteriaDto searchCriteria)
    {
        //var baseUrl = _configuration["BookingApi:BaseUrl"];
        //var apiKey = _configuration["BookingApi:ApiKey"];
        //var apiHost = _configuration["BookingApi:ApiHost"];
        

        var searchreq = ApiRequestHelper.CreateFlightRequest(_configuration, "searchFlights", searchCriteria);

        //var requestUrl = $"{baseUrl}searchFlights?fromId={searchCriteria.DepartureAirport}.AIRPORT&toId={searchCriteria.ArrivalAirport}.AIRPORT" +
        //                 $"&departDate={searchCriteria.DepartDate:yyyy-MM-dd}&adults={searchCriteria.AdultPassengers}" +
        //                 $"&sort=BEST&cabinClass={searchCriteria.CabinClass}&currency_code={searchCriteria.Currency}";

        //var request = new HttpRequestMessage
        //{
        //    Method = HttpMethod.Get,
        //    RequestUri = new Uri(requestUrl)
        //};

        //request.Headers.Add("x-rapidapi-key", apiKey);
        //request.Headers.Add("x-rapidapi-host", apiHost);


        using (var response = await _httpClient.SendAsync(searchreq))
        {
            response.EnsureSuccessStatusCode();
            var flightdata2 = await response.Content.ReadAsStringAsync();
            var flightData = await response.Content.ReadFromJsonAsync<BookingFlightApiResponseModel>();

            Airline airline = await IataCodeIsExists(flightData);

            Airport departureAirport = await DepartureAirportIsExists(flightData);

            Airport arrivalAirport = await ArrivalAirportIsExists(flightData);


            return flightData.data.flightOffers.Select(f => new SearchFlightQueryResponse
            {
                DepartureAirportId = departureAirport.Id,
                DepartureAirportName = departureAirport.Name,
                DepartureTime = f.segments.FirstOrDefault()?.departureTime ?? DateTime.MinValue,
                ArrivalAirportId = arrivalAirport.Id,
                ArrivalAirportName = arrivalAirport.Name,
                ArrivalTime = f.segments.FirstOrDefault()?.arrivalTime ?? DateTime.MinValue,
                AirlineId = airline.Id,
                AirlineName = airline.Name,
                AirlineLogo = airline.LogoURL,
                FlightNumber = f.segments.FirstOrDefault().legs.FirstOrDefault().flightInfo.flightNumber,
                AdultPassengers = searchCriteria.adults,
                BrandedFareName = f.brandedFareInfo?.fareName ?? "N/A",
                CabinClass = f.segments.FirstOrDefault()?.legs?.FirstOrDefault()?.cabinClass ?? "Economy",
                Luggage = f.brandedFareInfo?.features?.FirstOrDefault()?.label ?? "No Luggage",
                Price = f.priceBreakdown?.total?.units ?? 0 ,
                Token = f.token
            }).ToList();
        }
    }

    private async Task<Domain.Entities.Airline> IataCodeIsExists(BookingFlightApiResponseModel model)
    {
        var iataCode = model.data.flightOffers
            .FirstOrDefault()?
            .segments.FirstOrDefault()?
            .legs.FirstOrDefault()?
            .carriers.FirstOrDefault();

        if (iataCode == null)
            throw new Exception("Iata Code could not be found");

        var airline = await _airlineRepository.GetAsync(a => a.IATACode == iataCode);

        return airline;
    }

    private async Task<Airport> DepartureAirportIsExists(BookingFlightApiResponseModel model)
    {
        var departureAirport = model.data.flightOffers.FirstOrDefault().segments.FirstOrDefault().departureAirport.code;

        if(departureAirport == null)
        {
            throw new Exception("Departure Airport could not be found");
        }

        var airport = await _airportRepository.GetAsync(a => a.AirportCode == departureAirport);

        return airport;
    }

    private async Task<Airport> ArrivalAirportIsExists(BookingFlightApiResponseModel model)
    {
        var arrivalAirport = model.data.flightOffers.FirstOrDefault().segments.FirstOrDefault().departureAirport.code;

        if (arrivalAirport == null)
        {
            throw new Exception("Departure Airport could not be found");
        }

        var airport = await _airportRepository.GetAsync(a => a.AirportCode == arrivalAirport);

        return airport;
    }



    //public async Task<GetFlightDetailsQueryResponse> GetFlightDetails(string token)
    //{
    //    var baseUrl = _configuration["BookingApi:BaseUrl"];
    //    var apiKey = _configuration["BookingApi:ApiKey"];
    //    var apiHost = _configuration["BookingApi:ApiHost"];

    //    var requestUrl = $"{baseUrl}getFlightDetails?currency_code=TRY";

    //    var request = new HttpRequestMessage
    //    {
    //        Method = HttpMethod.Get,
    //        RequestUri = new Uri(requestUrl),
    //    };

    //    request.Headers.Add("x-rapidapi-key", apiKey);
    //    request.Headers.Add("x-rapidapi-host", apiHost);

    //    using (var response = await _httpClient.SendAsync(request))
    //    {
    //        response.EnsureSuccessStatusCode();
    //        var flightData = await response.Content.ReadFromJsonAsync<BookingFlightApiGetFlightDetailsResponseModel>();
    //    }
    //}
}
