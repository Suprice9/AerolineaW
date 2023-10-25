using Domain.Modelo;

namespace Domain.DTOS
{
    public class AirportDto
    {
        public string AirportName { get; set; }

        public string Country { get; set; }

        public int AirplaneLimit { get; set; }

        public int AmountAirplane { get; set; }


    }
}
