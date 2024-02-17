using System.Text.Json.Serialization;

namespace AGS.EXCHANGE_RATE.ENTITES;

public class EntityType
{
    [JsonPropertyName("Nombre")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("RegistrosCambiarios")]
    public List<ExchangeRateRegistry> ExchangeRateRegistries { get; set; } = null!;

    public void AddExchangeRateRegistry(ExchangeRateRegistry exchangeRateRegistry) => ExchangeRateRegistries.Add(exchangeRateRegistry);
}