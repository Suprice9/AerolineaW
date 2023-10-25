using Domain.Modelo;

namespace Domain.DTOS
{
    public class PassengerDto
    {
        public string Name { set; get; }

        public int Weigth { set; get; }

        public string Country { set; get; }

        public string Phone { set; get; }

        public long Passport { set; get; }
    }
}
