namespace MyTemplate.UI.Components;

public partial class Theme
{
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await ThemeService.GetCurrentTheme(NavigationManager);
            await base.OnAfterRenderAsync(firstRender);
            await InvokeAsync(StateHasChanged);
        }

    }

}