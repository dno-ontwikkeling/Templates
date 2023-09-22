using Microsoft.Extensions.FileProviders;
using MyTemplate.Common;
using MyTemplate.Core;
using MyTemplate.Data;
using MyTemplate.UI;
using MyTemplate.Web;
using Serilog;
using Configuration = MyTemplate.Web.Configuration;

var builder = WebApplication.CreateBuilder(args);
//Logging
builder.Host.UseSerilog((hostBuilderContext, loggerConfiguration) => { loggerConfiguration.ReadFrom.Configuration(hostBuilderContext.Configuration); });

// Add services to the container.
builder.Services.AddRazorPages(options => { options.RootDirectory = "/"; });
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers();

//Own configs
builder.Services.ConfigureCommon(builder.Configuration);
builder.Services.ConfigureBlazorServerSideWebApp(builder.Configuration);
builder.Services.ConfigureUserInferface(builder.Configuration);
builder.Services.ConfigureCoreApplication(builder.Configuration);
builder.Services.ConfigureData(builder.Configuration);


var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "../MyTemplate.UI/Images")),
    RequestPath = new PathString("/Images")
});

Configuration.UseConfiguredRequestLocalization(app, builder.Configuration);

app.UseRouting();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();