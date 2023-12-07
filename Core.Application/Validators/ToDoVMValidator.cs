using Application.ViewModels.ToDo;
using FluentValidation;

namespace Validators
{
    public  class ToDoVMValidator : AbstractValidator<ToDoVM>
    {
        public ToDoVMValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .WithMessage("{PropertyName} is required")
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
            RuleFor(x => x.Description)
                .NotNull()
                .WithMessage("{PropertyName} is required")
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
        }
    }
}
