using System.ComponentModel.DataAnnotations;

namespace Domain.Modelo
{
    public class Airport2
    {
        [Key]
        public int Id { get; set; }

        public string AirportName { get; set; }

        public string Country { get; set; }
        public int AirplaneLimit { get; set; }

        public int AmountAirplane { get; set; }
    }
}
