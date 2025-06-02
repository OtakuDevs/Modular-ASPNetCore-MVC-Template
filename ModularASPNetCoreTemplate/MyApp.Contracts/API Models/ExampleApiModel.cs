using System.Text.Json.Serialization;

namespace MyApp.Contracts.API_Models;

public class ExampleApiModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}