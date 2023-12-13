namespace MyTemplate.UI.Components;


public partial class DarkModeToggle
{
    private bool _isDarkMode;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _isDarkMode = (await ThemeService.GetCurrentTheme(NavigationManager)).IsDarkMode;
            await base.OnAfterRenderAsync(firstRender);
            await InvokeAsync(StateHasChanged);
        }
   
    }
}