using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Prueba_tecnica_net.Data;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ApiService> _logger;

    public ApiService(HttpClient httpClient, ApplicationDbContext context, ILogger<ApiService> logger)
    {
        _httpClient = httpClient;
        _context = context;
        _logger = logger;
    }

    public async Task FetchAndStoreBalanceResponsibleParties(string code, string country, string name)
    {
        var url = $"https://api.opendata.esett.com/EXP01/BalanceResponsibleParties?code={code}&country={country}&name={name}";

        try
        {
            // Hacemos la solicitud HTTP GET
            var response = await _httpClient.GetStringAsync(url);
            if (string.IsNullOrWhiteSpace(response))
            {
                _logger.LogWarning("La respuesta de la API es vacía o nula.");
                return;
            }

            // Deserializamos la respuesta JSON
            var parties = JsonSerializer.Deserialize<List<BalanceResponsibleParty>>(response);
            // Log para ver los datos que recibimos
            _logger.LogInformation($"Datos recibidos: {JsonSerializer.Serialize(parties)}");

            if (parties == null || parties.Count == 0)
            {
                _logger.LogWarning("No data found for the given parameters.");
                return;
            }

            // Guardamos los datos en la base de datos
            foreach (var party in parties)
            {
                // Verificar que BrpCode no sea nulo ni vacío antes de agregarlo
                if (string.IsNullOrEmpty(party.BrpCode))
                {
                    _logger.LogWarning($"El BrpCode de la entidad con nombre {party.BrpName} es nulo o vacío. No se guardará.");
                }
                else
                {
                    // Solo añadir la entidad si no existe en la base de datos
                    if (!_context.BalanceResponsibleParties.Any(b => b.BrpCode == party.BrpCode))
                    {
                        _context.BalanceResponsibleParties.Add(party);
                    }
                    else
                    {
                        _logger.LogInformation($"La entidad con BrpCode {party.BrpCode} ya existe.");
                    }
                }
            }

            // Guardamos los cambios en la base de datos
            _logger.LogInformation("Guardando cambios en la base de datos...");
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error fetching or saving data: {ex.Message}");
        }
    }
}
