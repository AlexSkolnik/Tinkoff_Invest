using Microsoft.AspNetCore.Mvc;
using Tinkoff_Invest.WebApi.Services;

namespace Tinkoff_Invest.WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AdminController : ControllerBase
{
    private readonly ILogger<AdminController> _logger;
    private readonly UsersServiceSample _usersServiceSample;
    private readonly InstrumentsServiceSample _instrumentsServiceSample;
    private readonly OperationsServiceSample _operationsServiceSample;
    private readonly MarketDataServiceSample _marketDataServiceSample;

    public AdminController(
        ILogger<AdminController> logger,
        UsersServiceSample usersServiceSample,
        InstrumentsServiceSample instrumentsServiceSample,
        OperationsServiceSample operationsServiceSample,
        MarketDataServiceSample marketDataServiceSample)
    {
        _logger = logger;
        _usersServiceSample = usersServiceSample;
        _instrumentsServiceSample = instrumentsServiceSample;
        _operationsServiceSample = operationsServiceSample;
        _marketDataServiceSample = marketDataServiceSample;
    }

    [HttpGet]
    public async Task<IActionResult> GetUserInfoDescriptionAsync(CancellationToken ct)
    {
        var userInfoDescription = await _usersServiceSample.GetUserInfoDescriptionAsync(ct);
        _logger.LogInformation(userInfoDescription);
        return Ok(userInfoDescription);
    }

    [HttpGet]
    public async Task<IActionResult> GetInstrumentsDescription(CancellationToken ct)
    {
        var instrumentsDescription = await _instrumentsServiceSample.GetInstrumentsDescriptionAsync(ct);
        _logger.LogInformation(instrumentsDescription);
        return Ok(instrumentsDescription);
    }

    [HttpGet]
    public async Task<IActionResult> GetOperationsDescriptionAsync(CancellationToken ct)
    {
        var operationsDescription = await _operationsServiceSample.GetOperationsDescriptionAsync(ct);
        _logger.LogInformation(operationsDescription);
        return Ok(operationsDescription);
    }

    [HttpGet]
    public async Task<IActionResult> GetTradingStatusesAsync(
        [FromQuery] string instrumentUid = "ba64a3c7-dd1d-4f19-8758-94aac17d971b", CancellationToken ct = default)
    {
        var tradingStatuses =
            await _marketDataServiceSample.GetTradingStatusesAsync(ct, instrumentUid);
        _logger.LogInformation(tradingStatuses);
        return Ok(tradingStatuses);
    }
}