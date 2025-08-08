using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ExternalIdentities.CreateExternalIdentities;

/// <summary>
/// API response model for CreateExternalIdentities operation
/// </summary>
public class CreateExternalIdentitiesResponse
{
    /// <summary>
    /// The unique identifier of the created user
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Sale number
    /// </summary>
    public string SaleNumber { get; set; } = string.Empty;

    /// <summary>
    /// Customer
    /// </summary>
    public string Customer { get; set; } = string.Empty;

    /// <summary>
    /// Quantities
    /// </summary>
    public int Quantities { get; set; } = 0;

    /// <summary>
    /// Branch where the sale was made
    /// </summary>
    public string BranchSale { get; set; } = string.Empty;

    /// <summary>
    /// Unit prices
    /// </summary>
    public Double UnitPrices { get; set; }

    /// <summary>
    /// Discounts in percentage
    /// </summary>
    public int Discounts { get; set; } = 0;

    ///// <summary>
    ///// Cancelled/Not Cancelled
    ///// </summary>
    public ExternalIdentitiesCancel StatusCancel { get; set; }

}
