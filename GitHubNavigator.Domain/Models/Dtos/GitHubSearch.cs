using System.Text.Json.Serialization;

namespace GitHubNavigator.Domain.Models.Dtos;

public class GitHubSearch<T>
{
    [JsonPropertyName("edges")]
    public IEnumerable<GitHubEdge<T>>? Edges { get; set; }
}
