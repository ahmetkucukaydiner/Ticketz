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
using Ticketz.Application.Services.PaymentService;
using Ticketz.Infrastructure.ExternalServices.Payment;

namespace Ticketz.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IFlightService, BookingSearchFlightService>();
        services.AddHttpClient<BookingSearchFlightService>();
        services.AddLogging();
        services.AddScoped<IPaymentService, DummyPaymentService>();
        
        return services;
    }
}
