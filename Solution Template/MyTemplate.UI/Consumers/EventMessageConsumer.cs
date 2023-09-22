using EventAggregator.Blazor;
using MyTemplate.Common.Mediator;
using MyTemplate.UI.Interfaces.Events;

namespace MyTemplate.UI.Consumers;

public class EventMessageRequestConsumer : CommandRequestConsumer<EventMessageCommand>
{
    private readonly IEventAggregator _eventAggregator;

    public EventMessageRequestConsumer(IEventAggregator eventAggregator)
    {
        _eventAggregator = eventAggregator;
    }

    protected override async Task Consume(EventMessageCommand message, CancellationToken cancellationToken)
    {
        await _eventAggregator.PublishAsync(message.Event);
    }
}