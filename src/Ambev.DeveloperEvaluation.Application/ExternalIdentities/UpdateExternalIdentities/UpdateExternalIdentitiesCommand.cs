using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.ExternalIdentities.UpdateExternalIdentities;

/// <summary>
/// Command for deleting a ExternalIdentities
/// </summary>
public record UpdateExternalIdentitiesCommand : IRequest<UpdateExternalIdentitiesResponse>
{

    /// <summary>
    /// The ExternalIdentities object to update
    /// </summary>
    public Ambev.DeveloperEvaluation.Domain.Entities.ExternalIdentities ExternalIdentities { get; }

    /// <summary>
    /// Initializes a new instance of UpdateExternalIdentitiesCommand
    /// </summary>
    /// <param name="externalIdentities">The ExternalIdentities object to update</param>
    public UpdateExternalIdentitiesCommand(Ambev.DeveloperEvaluation.Domain.Entities.ExternalIdentities externalIdentities)
    {
        ExternalIdentities = externalIdentities;
    }
}
