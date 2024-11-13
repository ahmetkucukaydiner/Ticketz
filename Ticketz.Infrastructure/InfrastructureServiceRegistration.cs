using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Services.SearchFlightService;
using Ticketz.Infrastructure.ExternalServices.BookingFlightApi;

namespace Ticketz.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<ISearchFlightService, BookingFlightService>();
        services.AddHttpClient<BookingFlightService>();
        return services;
    }
}
