using System.Collections.ObjectModel;
using GitHubNavigator.Domain.Models;
using GitHubNavigator.Extensions;
using Microsoft.AspNetCore.Components.Web;

namespace GitHubNavigator.Pages;

public partial class SearchUsers
{
    private string AccessToken { get; set; } = "";
    private string SearchText { get; set; } = "";
    private List<UserViewModel> _usersTotal = new();
    private ObservableCollection<UserViewModel> _users = new();
    private int _totalPageCount = 1;
    private int _currentPage = 1;
    private const int PageSize = 12;

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

            return;
        }

        _totalPageCount = (int)Math.Ceiling(result.Value!.Count / (double)PageSize);
        _usersTotal.Clear();
        _usersTotal.AddRange(result.Value!);
        UpdateUsersPage(1);
    }

    private void UpdateUsersPage(int page)
    {
        if (_usersTotal.Count < PageSize)
        {
            _currentPage = 1;
            _users = new ObservableCollection<UserViewModel>(_usersTotal);

            return;
        }

        if (page < 1)
        {
            _currentPage = 1;
            _users = new ObservableCollection<UserViewModel>(_usersTotal.Take(PageSize));

            return;
        }

        _users = new ObservableCollection<UserViewModel>(_usersTotal.Skip((page - 1) * PageSize).Take(PageSize));
    }
}
