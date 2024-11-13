using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Ticketz.Application.DTOs.FlightDto;
using Ticketz.Application.Features.SearchFlights.Queries;
using Ticketz.Application.Features.SearchFlights.Queries.GetFlightDetails;
using Ticketz.Application.Features.SearchFlights.Queries.SearchFlight;
using Ticketz.Application.Services.Repositories;
using Ticketz.Application.Services.SearchFlightService;
using Ticketz.Domain.Entities;
using Ticketz.Infrastructure.ExternalServices.Helpers;
using Ticketz.Infrastructure.Models.BookingFlightApiModels;
using static Ticketz.Infrastructure.Models.BookingFlightApiModels.BookingFlightApiResponseModel;

namespace Ticketz.Infrastructure.ExternalServices.BookingFlightApi;

public class BookingFlightService : ISearchFlightService
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
        //    RequestUri = new Uri(searchreq),
        //};

        //request.Headers.Add("x-rapidapi-key", apiKey);
        //request.Headers.Add("x-rapidapi-host", apiHost);


        using (var response = await _httpClient.SendAsync(searchreq))
        {
            response.EnsureSuccessStatusCode();
            var flightData = await response.Content.ReadFromJsonAsync<BookingFlightApiResponseModel>();

            var iataCode = flightData.data.flightOffers.FirstOrDefault().segments.FirstOrDefault().legs.FirstOrDefault().carriers.FirstOrDefault();
            var airline = await _airlineRepository.GetAsync(a => a.IATACode == iataCode);

            var departure = flightData.data.flightOffers.FirstOrDefault().segments.FirstOrDefault().departureAirport.code;
            var departureAirport = await _airportRepository.GetAsync(a => a.AirportCode == departure);

            var arrival = flightData.data.flightOffers.FirstOrDefault().segments.FirstOrDefault().arrivalAirport.code;
            var arrivalAirport = await _airportRepository.GetAsync(a => a.AirportCode == arrival);

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
                FlightNumber = f.segments.FirstOrDefault().legs.FirstOrDefault().flightInfo.flightNumber,
                AdultPassengers = searchCriteria.AdultPassengers,
                BrandedFareName = f.brandedFareInfo?.fareName ?? "N/A",
                CabinClass = f.segments.FirstOrDefault()?.legs?.FirstOrDefault()?.cabinClass ?? "Economy",
                Luggage = f.brandedFareInfo?.features?.FirstOrDefault()?.label ?? "No Luggage",
                Price = f.priceBreakdown?.total?.units ?? 0
            }).ToList();
        }
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
