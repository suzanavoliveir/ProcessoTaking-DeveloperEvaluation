using Ambev.DeveloperEvaluation.Application.Users.DeleteUser;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.ExternalIdentities.DeleteExternalIdentities;

/// <summary>
/// Handler for processing DeleteExternalIdentitiesCommand requests
/// </summary>
public class DeleteExternalIdentitiesHandler : IRequestHandler<DeleteExternalIdentitiesCommand, DeleteExternalIdentitiesResponse>
{
    private readonly IExternalIdentitiesRepository _externalIdentitiesRepository;

    /// <summary>
    /// Initializes a new instance of DeleteExternalIdentitiesHandler
    /// </summary>
    /// <param name="externalIdentitiesRepository">The External Identities repository</param>
    /// <param name="validator">The validator for DeleteExternalIdentitiesCommand</param>
    public DeleteExternalIdentitiesHandler(
        IExternalIdentitiesRepository externalIdentitiesRepository)
    {
        _externalIdentitiesRepository = externalIdentitiesRepository;
    }

    /// <summary>
    /// Handles the DeleteUserCommand request
    /// </summary>
    /// <param name="request">The DeleteUser command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteExternalIdentitiesResponse> Handle(DeleteExternalIdentitiesCommand request, CancellationToken cancellationToken)
    {
        var success = await _externalIdentitiesRepository.DeleteAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"ID {request.Id} not found");

        return new DeleteExternalIdentitiesResponse { Success = true };
    }
}
