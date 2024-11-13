using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketz.Infrastructure.ExternalServices.Helpers;

public static class ApiRequestHelper
{
    public static HttpRequestMessage CreateFlightRequest<TCriteria>(IConfiguration configuration, string endpoint, TCriteria criteria)
    {
        var baseUrl = configuration["BookingApi:BaseUrl"];
        var apiKey = configuration["BookingApi:ApiKey"];
        var apiHost = configuration["BookingApi:ApiHost"];

        var queryParams = string.Join("&", typeof(TCriteria).GetProperties().Select(prop => $"{prop.Name}={Uri.EscapeDataString(prop.GetValue(criteria)?.ToString() ?? string.Empty)}"));

        var requestUrl = $"{baseUrl}{endpoint}?{queryParams}";

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(requestUrl)
        };

        request.Headers.Add("x-rapidapi-key", apiKey);
        request.Headers.Add("x-rapidapi-host", apiHost);

        return request;
    }
}
