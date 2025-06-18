using CarRentalApplication.DB.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class Filter : IActionFilter
{
    private readonly IServiceProvider _serviceProvider;

    public Filter(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    
    public void OnActionExecuting(ActionExecutingContext context)
    {
        foreach (var argument in context.ActionArguments)
        {
            var model = argument.Value;
            if (model is null)
                continue;

            var validatorType = typeof(IValidator<>).MakeGenericType(model.GetType());
            var validator = _serviceProvider.GetService(validatorType) as IValidator;

            if (validator is null)
                continue;

            var result = validator.Validate(new ValidationContext<object>(model));
            if (!result.IsValid)
            {
                var errors = result.Errors
                    .Select(e => new { e.PropertyName, e.ErrorMessage });
                context.Result = new BadRequestObjectResult(errors);
                return;
            }
        }
    }

    
    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is null)
            return;

        var ex = context.Exception;

        if (IsGenericExceptionOfType(ex, typeof(UnauthorizedException<>)))
        {
            context.Result = new ObjectResult(new { error = ex.Message })
            {
                StatusCode = 401
            };
            context.ExceptionHandled = true;
        }
        else if (IsGenericExceptionOfType(ex, typeof(NotFoundException<>)))
        {
            context.Result = new ObjectResult(new { error = ex.Message })
            {
                StatusCode = 404
            };
            context.ExceptionHandled = true;
        }
        else if (IsGenericExceptionOfType(ex, typeof(BadRequestException<>)))
        {
            context.Result = new ObjectResult(new { error = ex.Message })
            {
                StatusCode = 400
            };
            context.ExceptionHandled = true;
        }
        else
        {
            context.Result = new ObjectResult(new { error = "An unexpected error occurred." })
            {
                StatusCode = 500
            };
            context.ExceptionHandled = true;
        }
    }

    private bool IsGenericExceptionOfType(Exception ex, Type genericExceptionType)
    {
        var exType = ex.GetType();

        if (exType.IsGenericType && exType.GetGenericTypeDefinition() == genericExceptionType)
            return true;
        
        return false;
    }
}
