using System.Web;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace MyTemplate.UI.Services
{
    public class ThemeService(ILocalStorageService localStorageService)
    {
        
        private static readonly Theme[] Themes = {
            new Theme {
                IsDarkMode = false,
                Value = "light",
                Primary = "#3481e5",
                Secondary = "#5b6471",
                Base = "#ffffff",
                Header = "#f4f3f9",
                Sidebar = "#f4f3f9",
                Content = "#f8f7ff",
                TitleText = "#1b1d20",
                ContentText = "#1b1d20"
            },
            new Theme {
                IsDarkMode = true,
                Value = "dark",
                Primary = "#94c1ff",
                Secondary = "#c2cbdc",
                Base = "#121418",
                Header = "#1f2226",
                Sidebar = "#1f2226",
                Content = "#1b1d20",
                TitleText = "#e0e0e9",
                ContentText = "#e0e0e9"
            },
        };

        private const string DefaultTheme = "light";

        private const string QueryParameter = "theme";


        public Theme CurrentTheme { get; private set; } = Themes.First(x => x.Value == DefaultTheme);

        public async Task<Theme> GetCurrentTheme(NavigationManager navigationManager)
        {
            var uri = new Uri(navigationManager.ToAbsoluteUri(navigationManager.Uri).ToString());
            var query = HttpUtility.ParseQueryString(uri.Query);
            var value = query.Get(QueryParameter);
            if (value is null)
            {
                var storedValue = await (localStorageService.GetItemAsync<bool?>("darkMode"));
                 var isDarkMode = storedValue ?? false;
                CurrentTheme = isDarkMode ? Themes.First(x => x.Value == "dark") : Themes.First(x => x.Value == "light");
            }
            else
            {
                if (Array.Exists(Themes, theme => theme.Value == value))
                {
                    CurrentTheme = Themes.First(x => x.Value == value);
                    await localStorageService.SetItemAsync("darkMode", CurrentTheme.IsDarkMode);
                }
            }
            return CurrentTheme;
        }

        public void ToggleDarkMode(NavigationManager navigationManager)
        {
            var theme = DefaultTheme;
            if (!CurrentTheme.IsDarkMode)//current
            {
                theme = "dark";
            }
            var url = navigationManager.GetUriWithQueryParameter(QueryParameter, theme);
            navigationManager.NavigateTo(url, true);
        }

        public class Theme
        {
            public required string Value { get; init; }
            public  bool IsDarkMode { get; init; }
            public required string Primary { get; set; }
            public required string Secondary { get; set; }
            public required string Base { get; set; }
            public required string Header { get; set; }
            public required string Sidebar { get; set; }
            public required string Content { get; set; }
            public required string TitleText { get; set; }
            public required string ContentText { get; set; }
        }
    }
}