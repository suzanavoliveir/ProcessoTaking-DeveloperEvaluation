using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Represents a ExternalIdentities in the system with authentication and profile information.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class ExternalIdentities : BaseEntity, IExternalIdentities
{

    /// <summary>
    /// Identifier for the ExternalIdentities
    /// </summary>
    public Guid Id { get; }

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


    /// <summary>
    /// Gets the unique identifier of the ExternalIdentities.
    /// </summary>
    /// <returns>The ExternalIdentities's ID as a string.</returns>
    string IExternalIdentities.Id => Id.ToString();

    ///// <summary>
    ///// Gets the ExternalIdentities's role in the system.
    ///// </summary>
    ///// <returns>The ExternalIdentities's role as a string.</returns>
    //string IExternalIdentities.Role => Role.ToString();

    /// <summary>
    /// Initializes a new instance of the ExternalIdentities class.
    /// </summary>
    public ExternalIdentities()
    {
        DateSale = DateTime.UtcNow;
    }

    /// <summary>
    /// Performs validation of the ExternalIdentities entity using the ExternalIdentitiesValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">ExternalIdentitiesname format and length</list>
    /// <list type="bullet">Email format</list>
    /// <list type="bullet">Phone number format</list>
    /// <list type="bullet">Password complexity requirements</list>
    /// <list type="bullet">Role validity</list>
    /// 
    /// </remarks>
    //public ValidationResultDetail Validate()
    //{
    //    var validator = new ExternalIdentitiesValidator();
    //    var result = validator.Validate(this);
    //    return new ValidationResultDetail
    //    {
    //        IsValid = result.IsValid,
    //        Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
    //    };
    //}

    /// <summary>
    /// Activates the ExternalIdentities account.
    /// Changes the ExternalIdentities's status to Active.
    /// </summary>
    //public void Activate()
    //{
    //    Status = ExternalIdentitiesStatus.Active;
    //    UpdatedAt = DateTime.UtcNow;
    //}

    /// <summary>
    /// Deactivates the ExternalIdentities account.
    /// Changes the ExternalIdentities's status to Inactive.
    /// </summary>
    //public void Deactivate()
    //{
    //    Status = ExternalIdentitiesStatus.Inactive;
    //    UpdatedAt = DateTime.UtcNow;
    //}

}