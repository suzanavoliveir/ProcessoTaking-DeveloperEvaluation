using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.ExternalIdentities.GetExternalIdentities;

/// <summary>
/// Response model for GetUser operation
/// </summary>
public class GetExternalIdentitiesResult
{
    /// <summary>
    /// The unique identifier of the user
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The user's full name
    /// </summary>
    public string Name { get; set; } = string.Empty;

}
