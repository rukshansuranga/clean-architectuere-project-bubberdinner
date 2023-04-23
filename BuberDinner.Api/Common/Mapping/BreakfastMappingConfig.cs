using BuberBreakfast.Models;
using BuberDinner.Contracts.Breakfast;
using Mapster;

namespace BuberDinner.Api.Common.Mapping;

public class BreakfastMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateBreakfastRequest, Breakfast>()
            .Map(dest => dest, source => source.BreakfastDetails);
    }
}