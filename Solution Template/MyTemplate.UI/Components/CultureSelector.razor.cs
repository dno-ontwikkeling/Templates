﻿using Microsoft.AspNetCore.Components;
using MyTemplate.UI.Options;

namespace MyTemplate.UI.Components;

public partial class CultureSelector
{
    private SupportedCulture _selectedCulture = null!;
    private List<SupportedCulture> _cultures = new();


    protected override Task OnInitializedAsync()
    {
        var cultureInfo = Thread.CurrentThread.CurrentCulture;
        _cultures = SupportedCulturesOptions.Value.SupportedCultures;
        var clientCulture = _cultures.Find(x => x.Culture == cultureInfo.Name);
        if (clientCulture is null)
        {
            _selectedCulture = SupportedCulturesOptions.Value.SupportedCultures[0];
            RequestCultureChange(_selectedCulture);
        }
        else
        {
            _selectedCulture = clientCulture;
        }

        InvokeAsync(StateHasChanged);
        return base.OnInitializedAsync();
    }

    private void RequestCultureChange(object culture)
    {
        var supportedCulture = culture as SupportedCulture;

        var uri = new Uri(NavigationManager.Uri).GetComponents(UriComponents.PathAndQuery, UriFormat.Unescaped);
        if (supportedCulture != null)
        {
            var query = $"?culture={Uri.EscapeDataString(supportedCulture.Culture)}&redirectUri={Uri.EscapeDataString(uri)}";
            NavigationManager.NavigateTo("/Culture/SetCulture" + query, true);
        }
    }
}