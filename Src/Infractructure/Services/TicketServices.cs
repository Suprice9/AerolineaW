using Domain.DTOS;
using Domain.Interface;
using Domain.Modelo;
using Infractructure.Data;
using Microsoft.EntityFrameworkCore;
using Mapster;
using Microsoft.VisualBasic;

namespace Infractructure.Services
{
    public class TicketServices:ITicketServices
    {
        private readonly DataBase _dbContext;

        public TicketServices(DataBase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Ticket>> GetTicket()
        {
            var ticket = await _dbContext.Ticket
             .ToListAsync();

            return ticket;
        }

        public async Task MapTicketObject(TicketDto ticketDto)
        {
            var result = ticketDto.Adapt<Ticket>();

            var PassengerId = await _dbContext.Passenger.FirstOrDefaultAsync(p => p.Id == result.PassengerId);

            var AirplaneId = await _dbContext.Airplane.FirstOrDefaultAsync(a => a.Id == result.AirplaneId);

            var AirportArrivalId = await _dbContext.Airport1.FirstOrDefaultAsync(a => a.Id == result.AirportArrivalId);

            var AirportDepartureId = await _dbContext.Airport2.FirstOrDefaultAsync(a => a.Id == result.AirportDepartureId);

         
            await _dbContext.Ticket.AddAsync(result);

            AirplaneId.Status = "En vuelo";

            await _dbContext.SaveChangesAsync();
               
        }

        public static string RemainingTime(TicketDto ticket)
        {
            TimeSpan remainingTime = ticket.ArrivalTime - ticket.DepartureTime;

            string message = "Faltan " + remainingTime.Days + " Dias, " + remainingTime.Hours + " Horas y " + remainingTime.Minutes + " Minutos";
            return message;
        }

        public async Task<string> ModifyTicket(int id)
        {
            var ticket = await _dbContext.Ticket.FirstOrDefaultAsync(t => t.Id == id);

            if (ticket is null)
            {
                return "Ticket no encontrado";
            }
            else { 
            var airplane = await _dbContext.Airplane.FirstOrDefaultAsync(a => a.Id == ticket.AirplaneId);

            ticket.DepartureTime = ticket.ArrivalTime;

                airplane.Status = "Aterrizó";

            await _dbContext.SaveChangesAsync();

            return "Se modifico correctamente";
                  }
        }

        public async Task<string> DeleteTicket(int id)
        {
            var ticket = await _dbContext.Ticket.FindAsync(id);

            if (ticket != null)
            {
                _dbContext.Remove(ticket);
                await _dbContext.SaveChangesAsync();
                return "Se elimino correctamente";
            }
            else
            {
                return "Hubo un error";
            }
        }
    }
}
