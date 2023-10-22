using GitHubNavigator.Extensions;
using Microsoft.AspNetCore.Components.Web;

namespace GitHubNavigator.Pages;

public partial class SearchUsers
{
    private string AccessToken { get; set; } = "";
    private string SearchText { get; set; } = "";

    private async Task OnKeyDownAsync(KeyboardEventArgs args)
    {
        if (args.Key == "Enter")
        {
            await StartSearchAsync();
        }
    }

    private async Task StartSearchAsync()
    {
        if (string.IsNullOrWhiteSpace(SearchText) || string.IsNullOrWhiteSpace(AccessToken)) return;

        var result = await SearchUsersService.SearchUsersAsync(SearchText, AccessToken);
        if (!result.IsSuccess)
        {
            Snackbar.ShowError(result.Error);
        }
    }
}
