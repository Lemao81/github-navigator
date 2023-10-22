using System.Net.Http.Headers;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;

namespace GitHubNavigator.Domain.Extensions;

public static class GraphQLClientExtensions
{
    public static void AddHttpAuthorization(this IGraphQLClient client, string accessToken)
    {
        if (client is GraphQLHttpClient httpClient)
        {
            httpClient.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", accessToken);
        }
    }
}
