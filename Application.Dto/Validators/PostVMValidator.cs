using Application.ViewModels.Post;
using Application.ViewModels.ToDo;
using FluentValidation;

namespace Validators
{
    public  class PostVMValidator : AbstractValidator<PostVM>
    {
        public PostVMValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("{PropertyName} is required")
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
            RuleFor(x => x.Html)
                .NotNull()
                .WithMessage("{PropertyName} is required")
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
            RuleFor(x => x.Tags)
                .NotNull()
                .WithMessage("{PropertyName} is required")
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
        }
    }
}
