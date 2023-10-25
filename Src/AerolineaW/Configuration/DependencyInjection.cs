using Microsoft.CodeAnalysis.CSharp.Syntax;
using Domain.Interface;
using Infractructure.Services;
using Infractructure.Validation;
using FluentValidation;
using Domain.DTOS;

namespace AerolineaW.Configuration
{
    public static class DependencyInjection
    {
        public static void GetDependencyInjections(this IServiceCollection services)
        {
            services.AddScoped<IAirplaneServices, AirplaneServices>();
            services.AddScoped<IAirportServices, AirportServices>();
            services.AddScoped<IPassengerServices, PassengerServices>();
            services.AddScoped<ITicketServices, TicketServices>();
            services.AddScoped<IValidationManager,ValidationManagerService>();
            services.AddScoped<IValidator<AirplaneDto>, AirplaneValidation>();
            services.AddScoped<IValidator<AirportDto>,AirportValidation>();
            services.AddScoped<IValidator<PassengerDto>, PassengerValidation>();
            services.AddScoped<IValidator<TicketDto>, TicketValidation>();
        }
    }
}
