using ApiRest.Infraestructure.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRest.Infraestructure.Helpers.Validators
{
    public class ProductUpdateValidator: AbstractValidator<ProductDtoForUpdate>
    {
        public ProductUpdateValidator()
        {
            RuleFor(product => product.Nombre).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(product => product.Precio).NotNull().GreaterThan(0);
            RuleFor(product => product.Stock).NotNull().GreaterThan(0);
        }
    }
}
