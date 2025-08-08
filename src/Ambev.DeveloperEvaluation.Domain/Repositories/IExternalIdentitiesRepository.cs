using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for External Identitiesentity operations
/// </summary>
public interface IExternalIdentitiesRepository
{
    /// <summary>
    /// Creates a new External Identitiesin the repository
    /// </summary>
    /// <param name="sale">The External Identitiesto create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user</returns>
    Task<ExternalIdentities> CreateAsync(ExternalIdentities sale, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a External Identitiesby their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The External Identitiesif found, null otherwise</returns>
    Task<ExternalIdentities?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a External Identitiesby their email address
    /// </summary>
    /// <param name="email">The email address to search for</param>
    /// <param name="cancellationToken">Cancellation token</param>
    ///// <returns>The External Identitiesif found, null otherwise</returns>
    //Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a External Identitiesfrom the repository
    /// </summary>
    /// <param name="id">The unique identifier of the External Identitiesto delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the External Identitieswas deleted, false if not found</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
