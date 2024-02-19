using System.Text.Json.Serialization;

namespace AGS.EXCHANGE_RATE.ENTITES;

public class ExchangeRateRegistry
{
    [JsonPropertyName("EntidadBancaria")]
    public string BankEntity { get; set; } = null!;

    [JsonPropertyName("MontoCompra")]
    public decimal AmountBuy { get; set; }

    [JsonPropertyName("MontoVenta")]
    public decimal AmountSell { get; set; }

    [JsonPropertyName("UltimaActualizacion")]
    public DateTime LastUpdated {get; set;}

}
