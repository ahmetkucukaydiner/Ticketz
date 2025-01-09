using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Services.FlightService;
using Ticketz.Infrastructure.ExternalServices.BookingFlightApi;

namespace Ticketz.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IFlightService, BookingFlightService>();
        services.AddHttpClient<BookingFlightService>();
        services.AddLogging();
        return services;
    }
}
