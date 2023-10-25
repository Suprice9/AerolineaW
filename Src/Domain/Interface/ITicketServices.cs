using Domain.DTOS;
using Domain.Modelo;
namespace Domain.Interface
{
    public interface ITicketServices
    {
        Task<List<Ticket>> GetTicket();

        Task MapTicketObject(TicketDto ticketDto);

        Task<string> ModifyTicket(int id);

        Task<string> DeleteTicket(int id);
    }
}
