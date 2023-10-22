using GitHubNavigator.Domain.Models;
using GitHubNavigator.Domain.Models.Dtos;

namespace GitHubNavigator.Domain.Interfaces;

public interface IGitHubGraphQLQueryService
{
    Task<Result<List<GitHubUser>>> SearchUsersAsync(string searchText, string accessToken);
}
