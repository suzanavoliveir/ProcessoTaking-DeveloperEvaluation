using MediatR;

namespace Ambev.DeveloperEvaluation.Application.ExternalIdentities.DeleteExternalIdentities;

/// <summary>
/// Command for deleting a user
/// </summary>
public record DeleteExternalIdentitiesCommand : IRequest<DeleteExternalIdentitiesResponse>
{
    /// <summary>
    /// The unique identifier of the user to delete
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of DeleteUserCommand
    /// </summary>
    /// <param name="id">The ID of the user to delete</param>
    public DeleteExternalIdentitiesCommand(Guid id)
    {
        Id = id;
    }
}
