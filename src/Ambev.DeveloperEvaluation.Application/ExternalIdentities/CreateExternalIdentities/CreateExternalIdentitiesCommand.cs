using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.ExternalIdentities.CreateIExternalIdentities;

/// <summary>
/// Command for creating a new External Entities.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a External Entities.
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="CreateExternalIdentitiesResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="CreateExternalIdentitiesCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateExternalIdentitiesCommand : IRequest<CreateExternalIdentitiesResult>
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