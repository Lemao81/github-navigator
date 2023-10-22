using GitHubNavigator.Domain.Models;

namespace GitHubNavigator.Domain.Interfaces;

public interface ISearchUsersService
{
    Task<Result<List<UserViewModel>>> SearchUsersAsync(string searchText, string accessToken);
}
