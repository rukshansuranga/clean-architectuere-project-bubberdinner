using BuberDinner.Api.Validations.CustomeValidators;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Contracts.Breakfast;
using FluentValidation;

namespace BuberDinner.Api.Validations;

public class CreateBreakfastRequestValidator : AbstractValidator<CreateBreakfastRequest>
{
    public CreateBreakfastRequestValidator(IDateTimeProvider dateTimeProvider)
    {
        Include(new CreateBreakfastRequestSavoryItemsValidator());
        //RuleFor(x => x.Name).Length(3, 10);
        // RuleFor(x => x.StartDateTime).Must(x => x > dateTimeProvider.UtcNow);
        // RuleFor(x => x.EndDateTime).GreaterThan(x => x.StartDateTime);

        // RuleForEach(x => x.Savory).Must(NotBeEmpty).WithMessage("Savory must have at least one item");
        // RuleFor(x => x.StartDateTime).AfterSunrise(dateTimeProvider);

        //RuleFor(x => x.BreakfastDetails).SetValidator(new BreakfastDetailsValidator());
    }

    private static bool NotBeEmpty(string savoryItem)
    {
        return savoryItem.Length > 0;
    }
}