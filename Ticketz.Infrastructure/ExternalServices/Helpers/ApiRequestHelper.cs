using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketz.Infrastructure.ExternalServices.Helpers;

public static class ApiRequestHelper
{
    public static string ToApiFormat(this DateTime dateTime) => dateTime.ToString("yyyy-MM-dd");
    public static string? ToApiFormat(this DateTime? dateTime) => dateTime?.ToString("yyyy-MM-dd");

    public static HttpRequestMessage CreateFlightRequest<TCriteria>(IConfiguration configuration, string endpoint, TCriteria criteria)
    {
        var baseUrl = configuration["BookingApi:BaseUrl"];
        var apiKey = configuration["BookingApi:ApiKey"];
        var apiHost = configuration["BookingApi:ApiHost"];

        var queryParams = string.Join("&", typeof(TCriteria).GetProperties().Select(prop =>
        {
            var value = prop.GetValue(criteria);

            if (value is DateTime dateValue)
            {
                return $"{prop.Name}={Uri.EscapeDataString(dateValue.ToApiFormat())}";
            }

            if (value is DateTime? && value != null)
            {
                return $"{prop.Name}={Uri.EscapeDataString(((DateTime)value).ToApiFormat())}";
            }

            return $"{prop.Name}={Uri.EscapeDataString(value?.ToString() ?? string.Empty)}";
        }));

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
