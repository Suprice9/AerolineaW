using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOS;
using Domain.Interface;
using FluentValidation;
using FluentValidation.Results;

namespace Infractructure.Validation;


    public class ValidationManagerService : IValidationManager
    {
        private readonly IValidator<AirplaneDto> _validationAirplane;

        private readonly IValidator<AirportDto> _ValidationAirport;

        private readonly IValidator<PassengerDto> _ValidationPassenger;

        private readonly IValidator<TicketDto> _ValidatationTicket;

        public ValidationManagerService (IValidator<AirplaneDto> validationAirplane, IValidator<AirportDto> validationAirport, IValidator<PassengerDto> validationPassenger, IValidator<TicketDto> validatationTicket)
        {
            _validationAirplane = validationAirplane;
            _ValidationAirport = validationAirport;
            _ValidationPassenger = validationPassenger;
            _ValidatationTicket = validatationTicket;
        }

        public async Task<ValidationResult> ValidateAirplaneAsync(AirplaneDto addAirplane)
            => await _validationAirplane.ValidateAsync(addAirplane);
        

        public async Task<ValidationResult> ValidationAirport(AirportDto addAirport)
            => await _ValidationAirport.ValidateAsync(addAirport);
        

        public async Task<ValidationResult> ValidationPassenger(PassengerDto passenger)
            => await _ValidationPassenger.ValidateAsync(passenger);
        

        public async Task<ValidationResult> ValidationTicket(TicketDto addTicket)
            => await _ValidatationTicket.ValidateAsync(addTicket);
        
    }

