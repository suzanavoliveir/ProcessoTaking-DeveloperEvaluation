using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ExternalIdentities.CreateExternalIdentities;

/// <summary>
/// Represents a request to create a new External Identities in the system.
/// </summary>
public class CreateExternalIdentitiesRequest
{
    /// <summary>
    /// Sale number
    /// </summary>
    public string SaleNumber { get; set; } = string.Empty;

    /// <summary>
    /// Date when the sale was made
    /// </summary>
    public DateTime DateSale { get; set; }

    /// <summary>
    /// Customer
    /// </summary>
    public string Customer { get; set; } = string.Empty;

    /// <summary>
    /// Total sale amount
    /// </summary>
    public int TotalSaleAmout { get; set; } = 0;

    /// <summary>
    /// Branch where the sale was made
    /// </summary>
    public string BranchSale { get; set; } = string.Empty;

    /// <summary>
    /// Products
    /// </summary>
    public ExternalIdentitiesProduct Products { get; set; }

    /// <summary>
    /// Quantities
    /// </summary>
    public int Quantities { get; set; } = 0;

    /// <summary>
    /// Unit prices
    /// </summary>
    public Double UnitPrices { get; set; }

    /// <summary>
    /// Discounts in percentage
    /// </summary>
    public int Discounts { get; set; } = 0;

    /// <summary>
    /// Total amount for each item
    /// </summary>
    public Double TotalItem { get; set; }


    ///// <summary>
    ///// Cancelled/Not Cancelled
    ///// </summary>
    public ExternalIdentitiesCancel StatusCancel { get; set; }
  
}