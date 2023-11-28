using Microsoft.AspNetCore.Components.WebView.WindowsForms;

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