using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IExternalIdentitiesRepository using Entity Framework Core
/// </summary>
public class ExternalIdentitiesRepository : IExternalIdentitiesRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of ExternalIdentitiesRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public ExternalIdentitiesRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new ExternalIdentities in the database
    /// </summary>
    /// <param name="ExternalIdentities">The ExternalIdentities to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created ExternalIdentities</returns>
    public async Task<ExternalIdentities> CreateAsync(ExternalIdentities ExternalIdentities, CancellationToken cancellationToken = default)
    {
        await _context.ExternalIdentities.AddAsync(ExternalIdentities, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return ExternalIdentities;
    }

    /// <summary>
    /// Retrieves a ExternalIdentities by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the ExternalIdentities</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The ExternalIdentities if found, null otherwise</returns>
    public async Task<ExternalIdentities?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.ExternalIdentities.FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    /// <summary>
    /// Update a ExternalIdentities from the database
    /// </summary>
    /// <param name="id">The unique identifier of the ExternalIdentities to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the ExternalIdentities was deleted, false if not found</returns>
    public async Task<bool> UpdateAsync(Guid id, ExternalIdentities externalIdentities, CancellationToken cancellationToken = default)
    {
        var ExternalIdentities = await GetByIdAsync(id, cancellationToken);
        if (ExternalIdentities == null)
            return false;

        _context.ExternalIdentities.Update(externalIdentities);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <summary>
    /// Deletes a ExternalIdentities from the database
    /// </summary>
    /// <param name="id">The unique identifier of the ExternalIdentities to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the ExternalIdentities was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var ExternalIdentities = await GetByIdAsync(id, cancellationToken);
        if (ExternalIdentities == null)
            return false;

        _context.ExternalIdentities.Remove(ExternalIdentities);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }


}
