using System.ComponentModel.DataAnnotations;

namespace Domain.Modelo
{
    public class Passenger
    {
        [Key]
        public int Id { set; get; }

        public string Name { set; get; }

        public int Weigth { set; get; }

        public string Country { set; get; }

        public string Phone { set; get; }
         
        public long Passport  { set; get; }

    }
}
