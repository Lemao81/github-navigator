using System.Text.Json.Serialization;

namespace GitHubNavigator.Domain.Models.Dtos;

public class GitHubUser
{
    [JsonPropertyName("login")]
    public string? Login { get; set; }
    
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
