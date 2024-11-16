namespace Prueba_tecnica_net.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BalanceResponsiblePartyController : ControllerBase
{
    private readonly ApiService _apiService;

    public BalanceResponsiblePartyController(ApiService apiService)
    {
        _apiService = apiService;
    }

    // Endpoint para consultar y almacenar los datos de la API
    [HttpPost("fetch")]
    public async Task<IActionResult> FetchAndStoreBalanceResponsibleParties([FromBody] BalanceResponsiblePartyFilter filter)
    {
        if (filter == null)
        {
            return BadRequest("Invalid filter parameters.");
        }

        await _apiService.FetchAndStoreBalanceResponsibleParties(filter.Code, filter.Country, filter.Name);

        return Ok("Data fetched and stored successfully.");
    }
}