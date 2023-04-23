using BuberBreakfast.Models;
using BuberBreakfast.ServiceErrors;
using BuberDinner.Api.Controllers;
using BuberDinner.Api.Services.Breakfasts;
using BuberDinner.Contracts.Breakfast;
using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BuberBreakfast.Controllers;

public class BreakfastsController : ApiController
{
    private readonly IBreakfastService _breakfastService;
        private readonly IMapper _mapper;

    public BreakfastsController(IBreakfastService breakfastService, IMapper mapper)
    {
        _breakfastService = breakfastService;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request
    ,[FromServices] IValidator<CreateBreakfastRequest> validator)
    {
        // ValidationResult validationResult = validator.Validate(request);

        // if(!validationResult.IsValid)
        // {
        //     var modelStateDictionary = new ModelStateDictionary();
        //     foreach(ValidationFailure failure in validationResult.Errors)
        //     {
        //         modelStateDictionary.AddModelError(failure.PropertyName, failure.ErrorMessage);
        //     }

        //     return ValidationProblem(modelStateDictionary);
        // }

        ErrorOr<Breakfast> requestToBreakfastResult = _mapper.Map<Breakfast>(request);

        if (requestToBreakfastResult.IsError)
        {
            return Problem(requestToBreakfastResult.Errors);
        }

        var breakfast = requestToBreakfastResult.Value;
        ErrorOr<Created> createBreakfastResult = _breakfastService.CreateBreakfast(breakfast);

        return createBreakfastResult.Match(
            created => CreatedAtGetBreakfast(breakfast),
            errors => Problem(errors));
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id)
    {
        ErrorOr<Breakfast> getBreakfastResult = _breakfastService.GetBreakfast(id);

        return getBreakfastResult.Match(
            breakfast => Ok(MapBreakfastResponse(breakfast)),
            errors => Problem(errors));
    }

    // [HttpPut("{id:guid}")]
    // public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
    // {
    //     ErrorOr<Breakfast> requestToBreakfastResult = Breakfast.From(id, request);

    //     if (requestToBreakfastResult.IsError)
    //     {
    //         return Problem(requestToBreakfastResult.Errors);
    //     }

    //     var breakfast = requestToBreakfastResult.Value;
    //     ErrorOr<UpsertedBreakfast> upsertBreakfastResult = _breakfastService.UpsertBreakfast(breakfast);

    //     return upsertBreakfastResult.Match(
    //         upserted => upserted.IsNewlyCreated ? CreatedAtGetBreakfast(breakfast) : NoContent(),
    //         errors => Problem(errors));
    // }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id)
    {
        ErrorOr<Deleted> deleteBreakfastResult = _breakfastService.DeleteBreakfast(id);

        return deleteBreakfastResult.Match(
            deleted => NoContent(),
            errors => Problem(errors));
    }

    private static BreakfastResponse MapBreakfastResponse(Breakfast breakfast)
    {
        return new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet);
    }

    private CreatedAtActionResult CreatedAtGetBreakfast(Breakfast breakfast)
    {
        return CreatedAtAction(
            actionName: nameof(GetBreakfast),
            routeValues: new { id = breakfast.Id },
            value: MapBreakfastResponse(breakfast));
    }
}