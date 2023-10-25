using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOS;
using FluentValidation.Resources;
using FluentValidation.Results;

namespace Domain.Interface
{
    public interface IValidationManager
    {
        Task<ValidationResult> ValidateAirplaneAsync(AirplaneDto addAirplane);

        Task<ValidationResult> ValidationAirport(AirportDto addAirport);

        Task<ValidationResult> ValidationPassenger(PassengerDto passenger);

        Task<ValidationResult> ValidationTicket(TicketDto addTicket);

    }
}
