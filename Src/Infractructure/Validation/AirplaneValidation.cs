using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOS;
using FluentValidation;

namespace Infractructure.Validation
{
    public class AirplaneValidation:AbstractValidator <AirplaneDto>
    {
        public AirplaneValidation() {
            RuleFor(x => x.AmountPassenger).NotEmpty();

            RuleFor(x => x.Maxweight).NotEmpty();

            RuleFor(x => x.Company).NotEmpty();
        }


    }
}
