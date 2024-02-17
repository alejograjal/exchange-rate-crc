using System.Formats.Asn1;
using System.IO.Compression;
using AGS.EXCHANGE_RATE.ENTITES;
using AGS.EXCHANGE_RATE.SERVICES.External;
using AGS.EXCHANGE_RATE.SERVICES.Interfaces;

namespace AGS.EXCHANGE_RATE.SERVICES.Core;

public class ExchangeRateReaderComposer : IExchangeRateReaderComposer
{
    const string BCCRURL = "https://gee.bccr.fi.cr/IndicadoresEconomicos/Cuadros/frmConsultaTCVentanilla.aspx";

    private async Task<List<EntityType>> GetExchangesRatesFromPage()
    {
        List<EntityType> entityTypes = new List<EntityType>();
        var reader = new PageReader(BCCRURL);
        var tables = await reader.ExtractTablesFromHtml("DG");

        if (tables.Count == 0)
        {
            return entityTypes;
        }

        var dgTable = tables[0];
        string previousEntityType = string.Empty;
        foreach (var tr in dgTable.Descendants().Where(m => m.Name == "tr" && !m.HasClass("TituloTabla")))
        {
            var childElements = tr.Descendants().Where(m => m.Name == "td").ToList();
            if (childElements[0].InnerText.Replace("&nbsp;", "") != "")
            {
                previousEntityType = childElements[0].InnerText.Trim();
                entityTypes.Add(new EntityType() { Name = childElements[0].InnerText.Trim(), ExchangeRateRegistries = new List<ExchangeRateRegistry>() });
            }

            if (!String.IsNullOrEmpty(childElements[1].InnerText.Replace("&nbsp;", "")))
            {
                ExchangeRateRegistry exchangeRateRegistry = new()
                {
                    BankEntity = childElements[1].InnerText.Trim(),
                    AmountBuy = Double.Parse(childElements[2].InnerText.Trim()),
                    AmountSell = Double.Parse(childElements[3].InnerText.Trim()),
                    LastUpdated = DateTime.Parse(childElements[5].InnerText.Substring(0, 10).Trim())
                };

                entityTypes.Single(m => m.Name == previousEntityType).AddExchangeRateRegistry(exchangeRateRegistry);
            }
        }

        return entityTypes;
    }

    private List<EntityType> GetFilteredByBank(List<EntityType> entityTypes, string bankEntity = null!)
    {
        var filteredEntityTypes = new List<EntityType>();

        if (bankEntity == null)
        {
            return entityTypes;
        }

        foreach (var entityType in entityTypes)
        {
            var result = entityType.ExchangeRateRegistries.Where(m => m.BankEntity == (bankEntity ?? m.BankEntity)).ToList();
            if (result == null || result.Count == 0)
            {
                continue;
            }

            filteredEntityTypes.Add(new EntityType()
            {
                Name = entityType.Name,
                ExchangeRateRegistries = new List<ExchangeRateRegistry>() { result[0] }
            });

            break;
        }

        return filteredEntityTypes;
    }

    public async Task<List<EntityType>> GetExchangesRates(string entityType = null!, string bankEntity = null!)
    {
        var consult = await GetExchangesRatesFromPage();
        List<EntityType> banksByEntityType = consult.Where(m => m.Name == (entityType ?? m.Name)).ToList();

        if (banksByEntityType == null || banksByEntityType.Count == 0)
        {
            return new List<EntityType>();
        }

        var registries = banksByEntityType.Count > 0 ?
            GetFilteredByBank(banksByEntityType, bankEntity) :
            new List<EntityType>()
            {
                new EntityType()
                {
                    Name = banksByEntityType.First().Name,
                    ExchangeRateRegistries = banksByEntityType.First().ExchangeRateRegistries.Where(m => m.BankEntity == (bankEntity ?? m.BankEntity)).ToList()
                }
            };

        return registries;
    }
}