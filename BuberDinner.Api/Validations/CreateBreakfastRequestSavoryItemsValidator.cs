using BuberDinner.Contracts.Breakfast;
using FluentValidation;

namespace BuberDinner.Api.Validations;

public class CreateBreakfastRequestSavoryItemsValidator : AbstractValidator<CreateBreakfastRequest>
{
    public CreateBreakfastRequestSavoryItemsValidator()
    {
        RuleFor(x => x.Savory).NotEmpty();
    }
}