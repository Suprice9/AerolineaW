using Domain.DTOS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infractructure.Validation
{
    public class AirportValidation:AbstractValidator<AirportDto>
    {

        public AirportValidation() {
            RuleFor(x => x.AirportName).NotEmpty();

            RuleFor(x => x.Country).NotEmpty();

            RuleFor(x => x.AirplaneLimit).NotEmpty();

            RuleFor(x => x.AmountAirplane).NotEmpty();
        }
    }
}
