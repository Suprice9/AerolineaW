using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOS;
using FluentValidation;

namespace Infractructure.Validation
{
    public class PassengerValidation:AbstractValidator<PassengerDto>
    {

        public PassengerValidation() {
            RuleFor(x => x.Name).NotEmpty();

            RuleFor(x => x.Weigth).NotEmpty();

            RuleFor(x=>x.Country).NotEmpty();

            RuleFor(x => x.Phone).NotEmpty();

            RuleFor(x=>x.Passport).NotEmpty();
        }
    }
}
