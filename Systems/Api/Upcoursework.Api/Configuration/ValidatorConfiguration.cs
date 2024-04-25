using FluentValidation.AspNetCore;
using Upcoursework.Common.Helpers;
using Upcoursework.Common.Validator;

namespace Upcoursework.Api.Configuration;

public static class ValidatorConfiguration
{
    public static IServiceCollection AddAppValidator(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation(opt => { opt.DisableDataAnnotationsValidation = true; });

        ValidatorsRegisterHelper.Register(services);

        services.AddSingleton(typeof(IModelValidator<>), typeof(ModelValidator<>));

        return services;
    }
}
