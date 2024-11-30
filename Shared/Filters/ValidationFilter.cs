using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Filters
{
    public class ValidationFilter<T> : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var validator = context.HttpContext.RequestServices.GetService<IValidator<T>>();

            if (validator is null)
                return await next(context);

            var requestModel = context.Arguments.OfType<T>().FirstOrDefault();

            if (requestModel is null)
                return await next(context);

            var validatorResult = await validator.ValidateAsync(requestModel);

            if (!validatorResult.IsValid)
                return Results.ValidationProblem(validatorResult.ToDictionary());

            return await next(context);
        }
    }
}
