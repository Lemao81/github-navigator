using GitHubNavigator.Domain.Models.Dtos;

namespace GitHubNavigator.Domain.Services;

public class StateContainer
{
    public List<GitHubUser> SearchedUsers { get; } = new();
}
