using MassTransit;
using MyTemplate.Common;
using MyTemplate.Core;
using MyTemplate.Data;
using MyTemplate.UI;

namespace MyTemplate.Web;

public static class Configuration
{
    public static IServiceCollection ConfigureBlazorServerSideWebApp(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddMediator(options =>
        {
            options.ConfigureMediatorForCommonLibrary();
            options.ConfigureMediatorForUILibrary();
            options.ConfigureMediatorForCoreLibrary();
            options.ConfigureMediatorForDataLibrary();
        });


        return services;
    }

    public static void UseConfiguredRequestLocalization(WebApplication app, IConfiguration config)
    {
        app.UseRequestLocalization(GetLocalizationOptions(config));
    }

    private static RequestLocalizationOptions GetLocalizationOptions(IConfiguration config)
    {
        var cultures = config.GetSection("SupportedCulturesOptions:SupportedCultures").GetChildren()
            .ToDictionary(x => x["Culture"]!, x => x["Display"]!);
        var supportedCultures = cultures.Keys.ToArray();
        var localizationOptions = new RequestLocalizationOptions()
            .AddSupportedCultures(supportedCultures)
            .AddSupportedUICultures(supportedCultures);
        return localizationOptions;
    }
}