using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Domain.DTOS;
using Infractructure.Data;

namespace Infractructure.Validation
{
    public class TicketValidation:AbstractValidator<TicketDto>
    {

        public TicketValidation(DataBase dataBase) {
            RuleFor(x => x.PassengerId).NotEmpty().Configure(config=>config.CascadeMode=CascadeMode.Stop)
                .CheckPassengerExistAsync(dataBase);

            RuleFor(x => x.AirplaneId).NotEmpty().Configure(config=>config.CascadeMode=CascadeMode.Stop)
                .CheckAirplaneExistAsync(dataBase);

            RuleFor(x => x.AirportArrivalId).NotEmpty().Configure(config => config.CascadeMode = CascadeMode.Stop)
                .CheckAirportArrivalAsync(dataBase);

            RuleFor(x => x.AirportDepartureId).NotEmpty().Configure(config => config.CascadeMode = CascadeMode.Stop)
                .CheckAiportDepartureAsync(dataBase);

            RuleFor(x => x.ArrivalTime).NotEmpty().Configure(config => config.CascadeMode = CascadeMode.Stop);

            RuleFor(x => x.DepartureTime).NotEmpty().Configure(config => config.CascadeMode = CascadeMode.Stop);
        }
    }
}
