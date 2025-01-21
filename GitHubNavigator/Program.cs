using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using GitHubNavigator;
using GitHubNavigator.Domain.Interfaces;
using GitHubNavigator.Domain.Services;
using GitHubNavigator.Extensions;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddGraphQLClient();

builder.Services.AddSingleton<StateContainer>();

builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<ISearchUsersService, SearchUsersService>();
builder.Services.AddGitHubGraphQLQueryService();

await builder.Build().RunAsync();
