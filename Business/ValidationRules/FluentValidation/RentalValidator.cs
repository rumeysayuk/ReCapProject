using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.RentDate).NotEmpty().NotNull();
            RuleFor(r => r.ReturnDate).NotEmpty().NotNull();
            RuleFor(r => r.CustomerId).NotEmpty().NotNull();
        }
    }
}
