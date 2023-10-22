using GitHubNavigator.Domain.Models;
using GitHubNavigator.Domain.Models.Dtos;

namespace GitHubNavigator.Domain.Extensions;

public static class GitHubUserExtensions
{
    public static UserViewModel MapToViewModel(this GitHubUser user) => new(Login: user.Login ?? "", Name: user.Name ?? "");
}
