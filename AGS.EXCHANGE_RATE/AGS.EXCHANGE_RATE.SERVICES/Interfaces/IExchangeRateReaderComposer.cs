using AGS.EXCHANGE_RATE.ENTITES;

namespace AGS.EXCHANGE_RATE.SERVICES.Interfaces;

public interface IExchangeRateReaderComposer
{
    Task<List<EntityType>> GetExchangesRates(string entityType = null!, string bankEntity = null!);
}