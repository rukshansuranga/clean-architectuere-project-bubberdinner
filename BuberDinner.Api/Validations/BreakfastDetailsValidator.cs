using BuberDinner.Contracts.Breakfast.Common;
using FluentValidation;

public class BreakfastDetailsValidator : AbstractValidator<BreakfastDetails>
{
    public BreakfastDetailsValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.StartDateTime).NotEmpty();
        RuleFor(x => x.EndDateTime).NotEmpty();
    }
}