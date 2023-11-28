using Blazored.LocalStorage;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyTemplate.UI.Options;
using MyTemplate.UI.Services;
using Radzen;

namespace MyTemplate.UI;

public static class Configuration
{
    public static void ConfigureUserInterface(this IServiceCollection services, IConfiguration config)
    {
        services.ConfigureLocalization();
        services.AddRadzenComponents();
        services.AddEventAggregator(options => options.AutoRefresh = true);
        services.AddBlazoredLocalStorage();
        services.AddScoped<ThemeService>();
    }

    public static void ConfigureMediatorForUiLibrary(this IMediatorRegistrationConfigurator options)
    {
        options.AddConsumers(typeof(Configuration).Assembly);
    }

    private static void ConfigureLocalization(this IServiceCollection services)
    {
        services.AddOptions<SupportedCulturesOptions>().BindConfiguration(nameof(SupportedCulturesOptions));
        services.AddLocalization();
    }
}