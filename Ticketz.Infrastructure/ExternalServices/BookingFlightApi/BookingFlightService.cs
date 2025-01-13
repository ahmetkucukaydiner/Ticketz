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
        var searchreq = ApiRequestHelper.CreateFlightRequest(_configuration, "searchFlights", searchCriteria);

        using (var response = await _httpClient.SendAsync(searchreq))
        {
            response.EnsureSuccessStatusCode();
            var flightData = await response.Content.ReadFromJsonAsync<BookingFlightApiResponseModel>();

            Airport departureAirport = await DepartureAirportIsExists(flightData);

            Airport arrivalAirport = await ArrivalAirportIsExists(flightData);

            var iataCodes = flightData.data.flightOffers
           .SelectMany(f => f.segments)
           .SelectMany(s => s.legs)
           .SelectMany(l => l.carriers)
           .Distinct();

            var airlines = await IataCodeIsExists(iataCodes);


            return flightData.data.flightOffers.Select(f => new SearchFlightQueryResponse
            {
                DepartureAirportId = departureAirport.Id,
                DepartureAirportName = departureAirport.Name,
                DepartureTime = f.segments.FirstOrDefault()?.departureTime ?? DateTime.MinValue,
                ArrivalAirportId = arrivalAirport.Id,
                ArrivalAirportName = arrivalAirport.Name,
                ArrivalTime = f.segments.FirstOrDefault()?.arrivalTime ?? DateTime.MinValue,
                AirlineId = airlines.Id,
                AirlineName = airlines.Name,
                AirlineLogo = f.segments.FirstOrDefault().legs.FirstOrDefault().carriersData.FirstOrDefault().logo,
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

    private async Task<Domain.Entities.Airline> IataCodeIsExists(IEnumerable<string> iataCodes)
    {
       var airlines = await _airlineRepository.GetAsync(a => iataCodes.Contains(a.IATACode));

       return airlines;
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
        var arrivalAirport = model.data.flightOffers.FirstOrDefault().segments.FirstOrDefault().arrivalAirport.code;

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
