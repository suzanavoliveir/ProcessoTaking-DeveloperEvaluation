using Ambev.DeveloperEvaluation.Domain.Services;
using Rebus.Bus;

public class RebusMessageBus : IMessageBus
{
    private readonly IBus _bus;

    public RebusMessageBus(IBus bus)
    {
        _bus = bus;
    }

    public Task SendAsync<T>(T message, CancellationToken cancellationToken = default)
    {
        return _bus.Send(message);
    }
}