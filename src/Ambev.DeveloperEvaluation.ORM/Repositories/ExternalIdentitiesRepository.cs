using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IExternalIdentitiesRepository using Entity Framework Core
/// </summary>
public class ExternalIdentitiesRepository : IExternalIdentitiesRepository
{
    private readonly DefaultContext _context;
    private readonly ILogger<ExternalIdentitiesRepository> _logger;

    /// <summary>
    /// Initializes a new instance of ExternalIdentitiesRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public ExternalIdentitiesRepository(DefaultContext context, ILogger<ExternalIdentitiesRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Creates a new ExternalIdentities in the database
    /// </summary>
    /// <param name="ExternalIdentities">The ExternalIdentities to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created ExternalIdentities</returns>
    public async Task<ExternalIdentities> CreateAsync(ExternalIdentities ExternalIdentities, CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogInformation("Creating ExternalIdentities: {ExternalIdentities}", ExternalIdentities);
            await _context.ExternalIdentities.AddAsync(ExternalIdentities, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Created with Sucess ExternalIdentities with ID: {Id}", ExternalIdentities.Id);
            return ExternalIdentities;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error Creating ExternalIdentities: {ExternalIdentities}", ExternalIdentities);
            return null;
        }

    }

    /// <summary>
    /// Retrieves a ExternalIdentities by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the ExternalIdentities</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The ExternalIdentities if found, null otherwise</returns>
    public async Task<ExternalIdentities?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogInformation("Retrieving ExternalIdentities with ID: {Id}", id);
            return await _context.ExternalIdentities.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error Retrieving ExternalIdentities with ID: {Id}", id);
            return null;
        }
            
    }

    /// <summary>
    /// Update a ExternalIdentities from the database
    /// </summary>
    /// <param name="id">The unique identifier of the ExternalIdentities to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the ExternalIdentities was deleted, false if not found</returns>
    public async Task<bool> UpdateAsync(ExternalIdentities externalIdentities, CancellationToken cancellationToken = default)
    {
        try
        {
            _context.ExternalIdentities.Update(externalIdentities);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Updated with Sucess ExternalIdentities with ID: {Id}", externalIdentities.Id);
            return true;

        }catch (Exception ex)
        {
            _logger.LogError(ex, "Error Updating ExternalIdentities: {ExternalIdentities}", externalIdentities);
            return false;
        }
        
    }

    /// <summary>
    /// Deletes a ExternalIdentities from the database
    /// </summary>
    /// <param name="id">The unique identifier of the ExternalIdentities to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the ExternalIdentities was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try {            
            var ExternalIdentities = await GetByIdAsync(id, cancellationToken);
            if (ExternalIdentities == null)
                return false;

            _context.ExternalIdentities.Remove(ExternalIdentities);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Deleted with Sucess ExternalIdentities with ID: {Id}", id);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error Deleting ExternalIdentities with ID: {Id}", id);
            return false;
        }
        
    }


}
