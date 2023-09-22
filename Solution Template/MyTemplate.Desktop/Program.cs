using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyTemplate.Common;
using MyTemplate.Core;
using MyTemplate.Data;
using MyTemplate.UI;
using Serilog;
using Serilog.Core;
using Log = Microsoft.VisualBasic.Logging.Log;

namespace MyTemplate.Desktop;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        AppDomain.CurrentDomain.UnhandledException += (sender, error) => { MessageBox.Show(error.ExceptionObject.ToString(), "Error"); };
        System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
        System.Windows.Forms.Application.EnableVisualStyles();
        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

        ApplicationConfiguration.Initialize();
        var host = CreateHostBuilder().Build();
        var logger = host.Services.GetRequiredService<ILogger>();
        logger.Information("Starting application MyTemplate");
        System.Windows.Forms.Application.Run(host.Services.GetRequiredService<Application>());
    }

    private static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                //Own configs
                services.ConfigureDesktopApplication(context.Configuration);
                services.ConfigureCommon(context.Configuration);
                services.ConfigureUserInferface(context.Configuration);
                services.ConfigureCoreApplication(context.Configuration);
                services.ConfigureData(context.Configuration);
                services.AddTransient<Application>();
            });
    }
}