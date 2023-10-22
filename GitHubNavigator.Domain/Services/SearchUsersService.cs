using GitHubNavigator.Domain.Extensions;
using GitHubNavigator.Domain.Interfaces;
using GitHubNavigator.Domain.Models;

namespace GitHubNavigator.Domain.Services;

public class SearchUsersService : ISearchUsersService
{
    private readonly IGitHubGraphQLQueryService _gitHubGraphQlQueryService;

    public SearchUsersService(IGitHubGraphQLQueryService gitHubGraphQlQueryService)
    {
        _gitHubGraphQlQueryService = gitHubGraphQlQueryService;
    }

    public async Task<Result<List<UserViewModel>>> SearchUsersAsync(string searchText, string accessToken)
    {
        var result = await _gitHubGraphQlQueryService.SearchUsersAsync(searchText, accessToken);
        if (!result.IsSuccess)
        {
            return Result<List<UserViewModel>>.Failure(result.Error!);
        }

        var viewModels = result.Value!.Select(u => u.MapToViewModel()).ToList();

        return Result<List<UserViewModel>>.Success(viewModels);
    }
}
