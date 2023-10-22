using GitHubNavigator.Domain.Extensions;
using GitHubNavigator.Domain.Interfaces;
using GitHubNavigator.Domain.Models;
using GitHubNavigator.Domain.Models.Dtos;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;

namespace GitHubNavigator.Domain.Services;

public class GitHubGraphQLQueryService : IGitHubGraphQLQueryService
{
    private readonly IGraphQLClient _graphQlClient;

    public GitHubGraphQLQueryService(IGraphQLClient graphQlClient)
    {
        _graphQlClient = graphQlClient;
    }

    public async Task<Result<List<GitHubUser>>> SearchUsersAsync(string searchText, string accessToken)
    {
        try
        {
            _graphQlClient.AddHttpAuthorization(accessToken);
            var request = new GraphQLRequest
            {
                Query = $$"""
                        {
                          search (query: "{{searchText}}", type: USER, first: 20){
                            edges {
                              node {
                                ... on User {
                                  login,
                                  name
                                }
                              }
                            }
                          }
                        }
                        """
            };

            var response = await _graphQlClient.SendQueryAsync<GitHubSearchData<GitHubUser>>(request);
            var users = response.Data.Search?.Edges?.Select(e => e.Node).ToList() ?? new List<GitHubUser?>();

            return Result<List<GitHubUser>>.Success(users!);
        }
        catch (GraphQLHttpRequestException httpRequestException)
        {
            Console.WriteLine(httpRequestException);

            return Result<List<GitHubUser>>.Failure("Something went wrong with the graphql request");
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);

            return Result<List<GitHubUser>>.Failure("An unknown error occurred");
        }
    }
}
