using FluentValidation;
using SnackStoreV3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackStoreV3.Validator
{
    public class EntityToValidateValidator:AbstractValidator<SnackModel>
    {
        public EntityToValidateValidator()
        {
            RuleFor(t => t.snackName).NotEmpty().Length(1, 50).WithMessage("Please specify a name");
            RuleFor(t => t.snackPrice).NotEmpty().GreaterThan(0).WithMessage("Please give a price higher that 0");
            RuleFor(t => t.snackQuantity).NotEmpty().GreaterThan(0).WithMessage("Please give a quantity higher that 0");
        }
          
    }
}
