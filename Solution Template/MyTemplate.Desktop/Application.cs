using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using System.Net.NetworkInformation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyTemplate.Common;
using MyTemplate.Core;
using MyTemplate.Data;
using MyTemplate.UI;

namespace MyTemplate.Desktop;

public partial class Application : Form
{
    public Application(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        blazorWebView1.HostPage = @"wwwroot\index.html";
        blazorWebView1.Services = serviceProvider;
        blazorWebView1.RootComponents.Add<App>("#app");
    }
}