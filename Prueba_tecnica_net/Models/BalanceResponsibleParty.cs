using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Prueba_tecnica_net.Models;

public class BalanceResponsibleParty
{
    [Key]
    [JsonPropertyName("brpCode")]
    public string BrpCode { get; set; } // El nombre que tiene la API es "brpCode"

    [JsonPropertyName("brpName")]
    public string BrpName { get; set; }

    [JsonPropertyName("businessId")]
    public string BusinessId { get; set; }

    [JsonPropertyName("codingScheme")]
    public string CodingScheme { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("validityStart")]
    public string ValidityStart { get; set; }

    [JsonPropertyName("validityEnd")]
    public string ValidityEnd { get; set; }
}

