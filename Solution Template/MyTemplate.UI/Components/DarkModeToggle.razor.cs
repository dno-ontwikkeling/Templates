using Microsoft.AspNetCore.Components;

namespace MyTemplate.UI.Components;


public partial class DarkModeToggle
{
    private bool IsDarkMode => ThemeService.IsDarkMode;

}