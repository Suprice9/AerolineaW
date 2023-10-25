using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Modelo
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Passenger")]
        public int PassengerId { get; set; }
        public Passenger? Passenger { get; set; }


        [ForeignKey("Airplane")]
        public int AirplaneId { set; get; }
        public Airplane? Airplane { set; get; }
        


        [ForeignKey("AirportArrival")]
        public int AirportArrivalId { get; set; }
        public Airport1? AirportArrival { get; set; }


        [ForeignKey("AirportDeparture")]
        public int AirportDepartureId { get; set; }
        public Airport2? AirportDeparture { get; set; }

        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }

    }
}
