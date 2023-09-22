using MyTemplate.Common.Events;
using MyTemplate.Common.Mediator;

namespace MyTemplate.UI.Interfaces.Events;

public record EventMessageCommand(IEventMessage Event) : ICommandRequest;