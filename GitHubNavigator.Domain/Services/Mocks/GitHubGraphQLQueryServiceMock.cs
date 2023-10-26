using Bogus;
using GitHubNavigator.Domain.Interfaces;
using GitHubNavigator.Domain.Models;
using GitHubNavigator.Domain.Models.Dtos;

namespace GitHubNavigator.Domain.Services.Mocks;

public class GitHubGraphQLQueryServiceMock : IGitHubGraphQLQueryService
{
    public Task<Result<List<GitHubUser>>> SearchUsersAsync(string searchText, string accessToken)
    {
        var faker = new Faker<GitHubUser>()
            .RuleFor(u => u.Login, f => f.Person.UserName)
            .RuleFor(u => u.Name, f => f.Name.FullName());

        return Task.FromResult(Result<List<GitHubUser>>.Success(faker.Generate(50)));
    }
}
