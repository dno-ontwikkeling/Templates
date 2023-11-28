using MassTransit;
using MassTransit.Mediator;

namespace MyTemplate.Common.Mediator;

public static class RequestExtension
{
    public static async Task<TResponse> Request<TRequest, TResponse>(this IMediator mediator, TRequest request, CancellationToken cancellation = default,
        RequestTimeout timeout = default) where TRequest : class, IDataRequest<TResponse> where TResponse : class
    {
        var client = mediator.CreateRequestClient<TRequest>();
        var response = await client.GetResponse<TResponse>(request, cancellation);
        var result = response.Message;
        return result ?? throw new NullReferenceException();
    }
}