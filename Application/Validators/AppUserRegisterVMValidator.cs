﻿using FluentValidation;
using ViewModels.Account;

namespace Validators
{
    public class AppUserRegisterVMValidator : AbstractValidator<AppUserSaveVM>
    {
        public AppUserRegisterVMValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("{PropertyName} is required")
                                 .EmailAddress().WithMessage("{PropertyName} is not valid");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("{PropertyName} is not equal to {ComparisonValue}");

        }

    }
}