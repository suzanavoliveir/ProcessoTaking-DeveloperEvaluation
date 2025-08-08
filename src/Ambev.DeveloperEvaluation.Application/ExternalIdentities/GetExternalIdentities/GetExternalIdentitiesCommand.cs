using MediatR;

namespace Ambev.DeveloperEvaluation.Application.ExternalIdentities.GetExternalIdentities;

/// <summary>
/// Command for retrieving a user by their ID
/// </summary>
public record GetExternalIdentitiesCommand : IRequest<GetExternalIdentitiesResult>
{
    /// <summary>
    /// The unique identifier of the user to retrieve
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of GetExternalIdentitiesCommand
    /// </summary>
    /// <param name="id">The ID of the user to retrieve</param>
    public GetExternalIdentitiesCommand(Guid id)
    {
        Id = id;
    }
}
