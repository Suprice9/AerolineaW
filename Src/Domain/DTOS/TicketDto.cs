using Domain.Modelo;

namespace Domain.DTOS
{
    public class TicketDto
    {
        public int PassengerId { get; set; }

        public int AirplaneId { set; get; }

        public int AirportArrivalId { get; set; }

        public int AirportDepartureId { get; set; }

        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
    }
}
