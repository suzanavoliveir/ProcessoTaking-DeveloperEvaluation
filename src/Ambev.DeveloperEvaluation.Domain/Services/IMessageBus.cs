    
namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public interface IMessageBus
    {
        Task SendAsync<T>(T message, CancellationToken cancellationToken = default);
    }
}
