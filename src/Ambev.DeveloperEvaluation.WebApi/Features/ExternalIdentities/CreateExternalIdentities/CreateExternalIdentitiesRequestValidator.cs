using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ExternalIdentities.CreateExternalIdentities;

/// <summary>
/// Validator for CreateExternalIdentitiesRequest that defines validation rules for user creation.
/// </summary>
public class CreateExternalIdentitiesRequestValidator : AbstractValidator<CreateExternalIdentitiesRequest>
{

    private readonly ILogger<ExternalIdentitiesController> _logger;

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
    public CreateExternalIdentitiesRequestValidator(ILogger<ExternalIdentitiesController> logger)
    {
        _logger = logger;

        // Não é possível vender mais de 20 itens idênticos
        RuleFor(sale => sale.Quantities)
            .Custom((quantities, context) =>
            {
                if (quantities > 20)
                {
                    context.AddFailure("Discounts", "It's not possible to sell above 20 identical items.");
                    _logger.LogError("Validation failed: Tried to sell {Quantities} items.", quantities);
                }
            });

        // Compras acima de 4 itens idênticos têm 10% de desconto
        RuleFor(sale => sale)
            .Custom((sale, context) =>
            {
                if (sale.Quantities > 4 && sale.Quantities < 10 && sale.Discounts != 10)
                {
                    context.AddFailure("Discounts", "Purchases above 4 identical items have a 10% discount.");
                    _logger.LogError("Validation failed: Sale {SaleNumber} with {Quantities} items should have 10% discount.", sale.SaleNumber, sale.Quantities);
                }
            });

        // Compras entre 10 e 20 itens idênticos têm 20% de desconto
        RuleFor(sale => sale)
            .Custom((sale, context) =>
            {
                if (sale.Quantities >= 10 && sale.Quantities <= 20 && sale.Discounts != 20)
                {
                    context.AddFailure("Discounts", "Purchases between 10 and 20 identical items have a 20% discount.");
                    _logger.LogError("Validation failed: Sale {SaleNumber} with {Quantities} items should have 20% discount.", sale.SaleNumber, sale.Quantities);
                }
            });

        // Compras abaixo de 4 itens não podem ter desconto
        RuleFor(sale => sale)
            .Custom((sale, context) =>
            {
                if (sale.Quantities < 4 && sale.Discounts != 0)
                {
                    context.AddFailure("Discounts", "Purchases below 4 items cannot have a discount.");
                    _logger.LogError("Validation failed: Sale {SaleNumber} with {Quantities} items should have 0% discount.", sale.SaleNumber, sale.Quantities);
                }
            });
    }
}