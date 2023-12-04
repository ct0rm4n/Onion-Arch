﻿using FluentValidation;
using ViewModels.Supplier;

namespace Validators
{
    public class SupplierSaveValidator : AbstractValidator<SupplierSaveVM>
    {
        public SupplierSaveValidator()
        {
            RuleFor(x => x.CompanyName)
                .NotNull()
                .WithMessage("{PropertyName} is required")
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
            RuleFor(x=>x.Address)
                .NotNull()
                .WithMessage("{PropertyName} is required")
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
        }
    }
}