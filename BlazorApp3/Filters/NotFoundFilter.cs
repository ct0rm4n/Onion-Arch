using Domain.Entities.Abstarct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services;
using ViewModels.Abstracts;
using ViewModels.ResultTypeViewModels;

namespace Filters
{
    public class NotFoundFilter<SaveViewModel, ViewModel, Entity> : IAsyncActionFilter
        where SaveViewModel : SaveVM
        where ViewModel : IBaseVM
        where Entity : class, IEntity

    {
        private readonly IGenericService<SaveViewModel, ViewModel, Entity> _genericService;

        public NotFoundFilter(IGenericService<SaveViewModel, ViewModel, Entity> genericService)
        {
            _genericService = genericService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            object? idValue = context.ActionArguments.Values.FirstOrDefault();
            if (idValue == null) 
            {
                await next.Invoke();
                return;
            }

            int id = (int)idValue; //int'e cast edilemezse ?
            SaveViewModel result = (await _genericService.FindAsync(id)).Data;
            if (result != null)
            {
                await next.Invoke();
                return;
            }

            ErrorVM errorVM = new ErrorVM();
            errorVM.Errors.Add($"{typeof(Entity).Name} with id {id} not found");
            context.Result = new RedirectToActionResult("Error", "Home", errorVM);


        }


    }
}
