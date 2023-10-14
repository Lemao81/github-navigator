using MudBlazor;

namespace GitHubNavigator.Shared;

public partial class MainLayout
{
    private readonly MudTheme _theme = new();
    private bool _isDrawerOpen = true;

    private void ToggleDrawer()
    {
        _isDrawerOpen = !_isDrawerOpen;
    }
}
