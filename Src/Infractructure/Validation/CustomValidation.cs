using FluentValidation;
using Infractructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infractructure.Validation;

public static class CustomValidation
{
    public static IRuleBuilderOptions<T, TElement> CheckPassengerExistAsync<T, TElement>(
    this IRuleBuilderOptions<T, TElement> ruleBuilderOptions,DataBase databaseContext)
    {
        return ruleBuilderOptions.MustAsync(async (Value, context) =>
        {
            var result = await databaseContext.Passenger.AnyAsync(w => w.Id == int.Parse(Value.ToString()),
                cancellationToken: context);

            if (!result)
            {
                return false;
            }

            return true;
        }).WithMessage("This {PropertyName} Not Found");
    }

    public static IRuleBuilderOptions<T, TElement> CheckAirplaneExistAsync<T, TElement>(
    this IRuleBuilderOptions<T, TElement> ruleBuilderOptions, DataBase databaseContext)
    {
        return ruleBuilderOptions.MustAsync(async (Value, context) =>
        {
            var result = await databaseContext.Airplane.AnyAsync(w => w.Id == int.Parse(Value.ToString()),
                cancellationToken: context);

            if (!result)
            {
                return false;
            }

            return true;
        }).WithMessage("This {PropertyName} Not Found");
    }

    public static IRuleBuilderOptions<T, TElement> CheckAirportArrivalAsync<T, TElement>(
    this IRuleBuilderOptions<T, TElement> ruleBuilderOptions, DataBase databaseContext)
    {
        return ruleBuilderOptions.MustAsync(async (Value, context) =>
        {
            var result = await databaseContext.Airport2.AnyAsync(w => w.Id == int.Parse(Value.ToString()),
                cancellationToken: context);

            if (!result)
            {
                return false;
            }

            return true;
        }).WithMessage("This {PropertyName} Not Found");
    }

    public static IRuleBuilderOptions<T, TElement> CheckAiportDepartureAsync<T, TElement>(
    this IRuleBuilderOptions<T, TElement> ruleBuilderOptions, DataBase databaseContext)
    {
        return ruleBuilderOptions.MustAsync(async (Value, context) =>
        {
            var result = await databaseContext.Airport1.AnyAsync(w => w.Id == int.Parse(Value.ToString()),
                cancellationToken: context);

            if (!result)
            {
                return false;
            }

            return true;
        }).WithMessage("This {PropertyName} Not Found");
    }


}
