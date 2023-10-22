using System.Text.Json.Serialization;

namespace GitHubNavigator.Domain.Models.Dtos;

public class GitHubSearchData<T>
{
    [JsonPropertyName("search")]
    public GitHubSearch<T>? Search { get; set; }
}
