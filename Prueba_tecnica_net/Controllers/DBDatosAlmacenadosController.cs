namespace Prueba_tecnica_net.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DBDatosAlmacenadosController : Controller
{
    private readonly IBalanceResponsiblePartyRepository _repository;

    public DBDatosAlmacenadosController(IBalanceResponsiblePartyRepository repository)
    {
        _repository = repository;
    }

    // GET: api/BalanceResponsibleParty
    [HttpGet]
    public async Task<ActionResult<List<BalanceResponsibleParty>>> GetAll()
    {
        try
        {
            var parties = await _repository.GetAllAsync();

            if (parties == null || !parties.Any())
            {
                return NoContent(); // Devuelve 204 si no hay datos
            }

            return Ok(parties); // Devuelve 200 con los datos
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno: {ex.Message}"); // Devuelve 500 en caso de error
        }
    }
}
