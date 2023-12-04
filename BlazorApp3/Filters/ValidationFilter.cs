using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ViewModels.ResponseViewModels;
using Wrappers;

namespace TrueOnion.WEB.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ModelState.IsValid) await next.Invoke();
            List<string> errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            context.Result = new BadRequestObjectResult(Result<NoContentVM>.Fail(StatusCodes.Status400BadRequest, errors));
        }
    }
}