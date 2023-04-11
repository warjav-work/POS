using FluentValidation;
using POS.Application.Dtos.Category.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Validators.Category
{
    public class CategoryValidator: AbstractValidator<CategoryRequestDto>
    {
        public CategoryValidator() 
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El campo Nombre no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Nombre no puede ser vacío.");

            RuleFor(x => x.Description)
                .NotNull().WithMessage("El campo Descripción no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Descripción no puede ser vacío.");
        }
    }
}
