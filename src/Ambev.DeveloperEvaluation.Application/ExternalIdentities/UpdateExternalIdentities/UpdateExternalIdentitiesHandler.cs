using Ambev.DeveloperEvaluation.Application.ExternalIdentities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.ExternalIdentities.UpdateExternalIdentities;

/// <summary>
/// Handler for processing DeleteExternalIdentitiesCommand requests
/// </summary>
public class UpdateExternalIdentitiesHandler : IRequestHandler<UpdateExternalIdentitiesCommand, UpdateExternalIdentitiesResponse>
{
    private readonly IExternalIdentitiesRepository _repository;

    public UpdateExternalIdentitiesHandler(IExternalIdentitiesRepository repository)
    {
        _repository = repository;
    }

    public async Task<UpdateExternalIdentitiesResponse> Handle(UpdateExternalIdentitiesCommand request, CancellationToken cancellationToken)
    {
        // Atualiza o objeto inteiro
        var success = await _repository.UpdateAsync(request.ExternalIdentities, cancellationToken);

        return new UpdateExternalIdentitiesResponse
        {
            Success = success
        };
    }
}

