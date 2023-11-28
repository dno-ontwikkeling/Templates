using EventAggregator.Blazor;
using MassTransit.Mediator;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MyTemplate.UI.Resources;

namespace MyTemplate.UI.Bases;

public class ComponentBase : Microsoft.AspNetCore.Components.ComponentBase, IDisposable
{
    [Inject] public IStringLocalizer<App> Localize { get; set; } = null!;
    [Inject] public IEventAggregator EventAggregator { get; set; } = null!;
    [Inject] public IMediator Mediator { get; set; } = null!;

    [Inject] public NavigationManager NavigationManager { get; set; } = null!;


    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
        if (firstRender) EventAggregator.Subscribe(this);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        EventAggregator.Unsubscribe(this);
    }
}