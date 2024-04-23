using FluentValidation;
using FluentValidation.Results;
using HaadCRM.Service.Exceptions;

namespace HaadCRM.Service.Extensions;

public static class ValidationExtensions
{
    public static async ValueTask<ValidationResult> ValidateOrPanicAsync<TValidator, TObject>(this TValidator validator,
        TObject @object)
        where TObject : class
        where TValidator : AbstractValidator<TObject>
    {
        var validationResult = await validator.ValidateAsync(@object);
        if (validationResult.Errors.Any())
            throw new ArgumentIsNotValidException(validationResult.Errors.First().ErrorMessage);

        return validationResult;
    }
}