using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Ticketz.Application.DTOs.FlightDto;
using Ticketz.Application.Features.Flights.Queries;
using Ticketz.Application.Services.Repositories;
using Ticketz.Application.Services.SearchFlightService;
using Ticketz.Domain.Entities;
using Ticketz.Infrastructure.Models;
using static Ticketz.Infrastructure.Models.BookingFlightApiResponseModel;

namespace Ticketz.Infrastructure.BookingFlightApi;

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

    public async Task<List<Flight>> SearchFlightAsync(FlightSearchCriteriaDto searchCriteria)
    {
        var baseUrl = _configuration["BookingApi:BaseUrl"];
        var apiKey = _configuration["BookingApi:ApiKey"];
        var apiHost = _configuration["BookingApi:ApiHost"];

        var requestUrl = $"https://booking-com15.p.rapidapi.com/api/v1/flights/searchFlights?fromId={searchCriteria.DepartureAirport}.AIRPORT&toId={searchCriteria.ArrivalAirport}.AIRPORT" +
                         $"&departDate={searchCriteria.DepartDate:yyyy-MM-dd}&adults={searchCriteria.AdultPassengers}" +
                         $"&sort=BEST&cabinClass={searchCriteria.CabinClass}&currency_code={searchCriteria.Currency}";

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(requestUrl),
        };

        request.Headers.Add("x-rapidapi-key", apiKey);
        request.Headers.Add("x-rapidapi-host", apiHost);


        using (var response = await _httpClient.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var flightData = await response.Content.ReadFromJsonAsync<BookingFlightApiResponseModel>();
            Console.WriteLine(body);   
        

        

        
        
        

        var iataCode = flightData.data.flightOffers.FirstOrDefault().segments.FirstOrDefault().legs.FirstOrDefault().carriers.FirstOrDefault();
        var airline = await _airlineRepository.GetAsync(a => a.IATACode == iataCode);

        var departure =flightData.data.flightOffers.FirstOrDefault().segments.FirstOrDefault().departureAirport.name;
        var departureAirport = await _airportRepository.GetAsync(a => a.Name == departure);

        var arrival = flightData.data.flightOffers.FirstOrDefault().segments.FirstOrDefault().arrivalAirport.name;
        var arrivalAirport = await _airportRepository.GetAsync(a => a.Name == arrival);

        return flightData.data.flightOffers.Select(f => new Flight
        {
            AdultPassengers = searchCriteria.AdultPassengers,
            AirlineId = airline.Id,
            ArrivalAirportId = arrivalAirport.Id,
            ArrivalTime = f.segments.FirstOrDefault().arrivalTime,
            BrandedFareName = f.brandedFareInfo.fareName,
            CabinClass = f.segments.FirstOrDefault().legs.FirstOrDefault().cabinClass,
            DepartureAirportId = departureAirport.Id,
            DepartureTime = f.segments.FirstOrDefault().departureTime,
            FlightNumber = f.segments.FirstOrDefault().legs.FirstOrDefault().flightInfo.flightNumber,
            Luggage = f.brandedFareInfo.features.FirstOrDefault().label,
            Price = f.priceBreakdown.total.units
        }).ToList();
    }
    }
}
