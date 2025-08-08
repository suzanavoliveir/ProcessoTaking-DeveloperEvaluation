using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ExternalIdentities.CreateExternalIdentities;

/// <summary>
/// Validator for CreateExternalIdentitiesRequest that defines validation rules for user creation.
/// </summary>
public class CreateExternalIdentitiesRequestValidator : AbstractValidator<CreateExternalIdentitiesRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateExternalIdentitiesRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// * [OK] Compras acima de 4 itens idênticos têm 10% de desconto
    //  * [OK] Compras entre 10 e 20 itens idênticos têm 20% de desconto
    //  * [OK] Não é possível vender mais de 20 itens idênticos
    //  * [OK] Compras abaixo de 4 itens não podem ter desconto

    /// </remarks>
    public CreateExternalIdentitiesRequestValidator()
    {
        // Não é possível vender mais de 20 itens idênticos
        RuleFor(sale => sale.Quantities)
            .LessThanOrEqualTo(20)
            .WithMessage("It's not possible to sell above 20 identical items.");

        // Compras acima de 4 itens idênticos têm 10% de desconto
        RuleFor(sale => sale.Discounts)
            .Must((sale, discount) => sale.Quantities > 4 && sale.Quantities < 10 ? discount == 10 : true)
            .WithMessage("Purchases above 4 identical items have a 10% discount.");

        // Compras entre 10 e 20 itens idênticos têm 20% de desconto
        RuleFor(sale => sale.Discounts)
            .Must((sale, discount) => sale.Quantities >= 10 && sale.Quantities <= 20 ? discount == 20 : true)
            .WithMessage("Purchases between 10 and 20 identical items have a 20% discount.");

        // Compras abaixo de 4 itens não podem ter desconto
        RuleFor(sale => sale.Discounts)
            .Must((sale, discount) => sale.Quantities < 4 ? discount == 0 : true)
            .WithMessage("Purchases below 4 items cannot have a discount.");
    }
}