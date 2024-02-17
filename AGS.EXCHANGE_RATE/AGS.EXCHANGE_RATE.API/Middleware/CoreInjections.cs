using AGS.EXCHANGE_RATE.SERVICES.Core;
using AGS.EXCHANGE_RATE.SERVICES.Interfaces;

namespace AGS.EXCHANGE_RATE.API.Middleware;

public static class CoreInjections
{
    public static void ConfigureMainInjections(this IServiceCollection services)
    {
        services.AddScoped<IExchangeRateReaderComposer, ExchangeRateReaderComposer>();
    }
}