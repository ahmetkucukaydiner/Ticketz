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
using Ticketz.Application.Services.SearchFlightService;
using Ticketz.Domain.Entities;
using Ticketz.Infrastructure.Models;
using static Ticketz.Infrastructure.Models.BookingFlightApiResponseModel;

namespace Ticketz.Infrastructure.BookingFlightApi;

public class BookingFlightService : ISearchFlightService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public BookingFlightService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }    

    public async Task<List<Flight>> SearchFlightAsync(FlightSearchCriteriaDto searchCriteria)
    {
        var baseUrl = _configuration["BookingApi:BaseUrl"];
        var apiKey = _configuration["BookingApi:ApiKey"];
        var apiHost = _configuration["BookingApi:ApiHost"];

        var requestUrl = $"{baseUrl}?fromId={searchCriteria.DepartureAirport}.AIRPORT&toId={searchCriteria.ArrivalAirport}.AIRPORT" +
                         $"&departdate={searchCriteria.DepartDate:yyyy-MM-dd}&adults={searchCriteria.AdultPassengers}" +
                         $"&sort=BEST&cabinClass={searchCriteria.CabinClass}&currency_code={searchCriteria.Currency}";

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(requestUrl),
        };

        request.Headers.Add("x-rapidapi-key", apiKey);
        request.Headers.Add("x-rapidapi-host", apiHost);

        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Uçuş arama başarısız oldu.");
        }

        var flightData = await response.Content.ReadFromJsonAsync<Rootobject>();

        if (flightData == null || flightData.data?.flightOffers == null)
        {
            return new List<Flight>();
        }

        return flightData.data.flightOffers.Select(f => new Flight
        {
            
        }).ToList();
    }

    private BookingFlightApiResponseModel ParseResponse(string responseBody)
    {
        try
        {
            var response = JsonConvert.DeserializeObject<BookingFlightApiResponseModel>(responseBody);
            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new Exception(ex.Message);
        }
    }
}
