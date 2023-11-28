using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyTemplate.Common;
using MyTemplate.Core;
using MyTemplate.Data;
using MyTemplate.UI;
using Serilog;

namespace MyTemplate.Desktop;

public static class Configuration
{
    public static void ConfigureDesktopApplication(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddSerilog((_, configuration) => { configuration.ReadFrom.Configuration(config); });
        services.AddWindowsFormsBlazorWebView();
        services.AddMediator(options =>
        {
            options.ConfigureMediatorForCommonLibrary();
            options.ConfigureMediatorForUiLibrary();
            options.ConfigureMediatorForCoreLibrary();
            options.ConfigureMediatorForDataLibrary();
        });
    }
}