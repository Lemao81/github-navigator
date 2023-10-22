using System.Text.Json.Serialization;

namespace GitHubNavigator.Domain.Models.Dtos;

public class GitHubEdge<T>
{
    [JsonPropertyName("node")]
    public T? Node { get; set; }
}
