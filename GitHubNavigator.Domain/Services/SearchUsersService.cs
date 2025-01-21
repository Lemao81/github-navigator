using GitHubNavigator.Domain.Extensions;
using GitHubNavigator.Domain.Interfaces;
using GitHubNavigator.Domain.Models;

namespace GitHubNavigator.Domain.Services;

public class SearchUsersService : ISearchUsersService
{
    private readonly IGitHubGraphQLQueryService _gitHubGraphQlQueryService;
    private readonly StateContainer _stateContainer;

    public SearchUsersService(IGitHubGraphQLQueryService gitHubGraphQlQueryService, StateContainer stateContainer)
    {
        _gitHubGraphQlQueryService = gitHubGraphQlQueryService;
        _stateContainer = stateContainer;
    }

    public async Task<Result<List<UserViewModel>>> SearchUsersAsync(string searchText, string accessToken)
    {
        var result = await _gitHubGraphQlQueryService.SearchUsersAsync(searchText, accessToken);
        if (!result.IsSuccess)
        {
            return Result<List<UserViewModel>>.Failure(result.Error!);
        }

        _stateContainer.SearchedUsers.Clear();
        _stateContainer.SearchedUsers.AddRange(result.Value!);

        var viewModels = result.Value!.Select(u => u.MapToViewModel()).ToList();

        return Result<List<UserViewModel>>.Success(viewModels);
    }
}
