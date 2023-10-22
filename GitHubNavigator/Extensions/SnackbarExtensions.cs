using MudBlazor;

namespace GitHubNavigator.Extensions;

public static class SnackbarExtensions
{
    public static void ShowError(this ISnackbar snackbar, string? error) => snackbar.Add(error, Severity.Error);
}
