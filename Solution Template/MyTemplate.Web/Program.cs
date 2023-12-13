using Microsoft.Extensions.FileProviders;
using MyTemplate.Common;
using MyTemplate.Core;
using MyTemplate.Data;
using MyTemplate.UI;
using MyTemplate.UI.Layouts;
using MyTemplate.Web;
using MyTemplate.Web.Components;
using Serilog;
using Configuration = MyTemplate.Web.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((hostBuilderContext, loggerConfiguration) => { loggerConfiguration.ReadFrom.Configuration(hostBuilderContext.Configuration); });


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddControllers();
builder.Services.AddHealthChecks();

//Own configs
builder.Services.ConfigureCommon(builder.Configuration);
builder.Services.ConfigureBlazorWebApp(builder.Configuration);
builder.Services.ConfigureUserInterface(builder.Configuration);
builder.Services.ConfigureCoreApplication(builder.Configuration);
builder.Services.ConfigureData(builder.Configuration);


var app = builder.Build();

app.MapHealthChecks("/status");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.UseStaticFiles();

if (Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "../MyTemplate.UI/StaticFiles")))
{
    app.UseStaticFiles(new StaticFileOptions()
    {
        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "../MyTemplate.UI/StaticFiles")),
        RequestPath = new PathString("/static-files")
    });
}

Configuration.UseConfiguredRequestLocalization(app, builder.Configuration);

app.UseAntiforgery();
app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(MainLayout).Assembly);  
app.Run();
