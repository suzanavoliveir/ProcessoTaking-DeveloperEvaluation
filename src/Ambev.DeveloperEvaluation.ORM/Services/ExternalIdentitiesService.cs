using Rebus.Bus;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Services;
using Ambev.DeveloperEvaluation.Domain.Messages.CreateExternalIdentities;
using Ambev.DeveloperEvaluation.Domain.Messages.GetExternalIdentities;
using Ambev.DeveloperEvaluation.Domain.Messages.DeleteExternalIdentities;
using Ambev.DeveloperEvaluation.Domain.Messages.UpdateExternalIdentities;

public class ExternalIdentitiesService : IExternalIdentitiesService
{
    private readonly IBus _bus;

    public ExternalIdentitiesService(IBus bus)
    {
        _bus = bus;
    }

    public async Task<ExternalIdentities> CreateAsync(ExternalIdentities externalIdentities, CancellationToken cancellationToken = default)
    {
        await _bus.Send(new CreateExternalIdentitiesMessage { ExternalIdentities = externalIdentities });
        return externalIdentities; // Retorno simplificado, pode ser ajustado conforme resposta do handler
    }

    public async Task<ExternalIdentities?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _bus.Send(new GetExternalIdentitiesByIdMessage { Id = id });
        return null; // Retorno simplificado, pode ser ajustado conforme resposta do handler
    }

    public async Task<bool> UpdateAsync(ExternalIdentities externalIdentities, CancellationToken cancellationToken = default)
    {
        await _bus.Send(new UpdateExternalIdentitiesMessage { ExternalIdentities = externalIdentities });
        return true; // Retorno simplificado, pode ser ajustado conforme resposta do handler
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _bus.Send(new DeleteExternalIdentitiesMessage { Id = id });
        return true; // Retorno simplificado, pode ser ajustado conforme resposta do handler
    }
}
