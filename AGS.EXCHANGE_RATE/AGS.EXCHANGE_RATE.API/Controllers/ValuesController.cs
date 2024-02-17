using AGS.EXCHANGE_RATE.ENTITES;
using AGS.EXCHANGE_RATE.ENTITES.Response;
using AGS.EXCHANGE_RATE.SERVICES.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AGS.EXCHANGE_RATE.API.Controllers;

[ApiController]
[Route("values")]
public class ValuesController : ControllerBase
{
    private readonly ILogger<ValuesController> Logger;
    private IExchangeRateReaderComposer ExchangeRateReaderComposer;

    public ValuesController(ILogger<ValuesController> logger, IExchangeRateReaderComposer exchangeRateReaderComposer) =>
        (Logger, ExchangeRateReaderComposer) =
        (logger, exchangeRateReaderComposer);

    [HttpGet]
    public async Task<APIResponse<List<EntityType>>> GetAll(string entityType = null!, string bankEntity = null!)
    {
        var result = await ExchangeRateReaderComposer.GetExchangesRates(entityType, bankEntity);
        var response = new APIResponse<List<EntityType>>()
        {
            Data = result,
            Message = "Exchange rate loaded",
        };

        return response;
    }
}