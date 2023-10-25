using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Modelo
{
    public class Airplane
    {
     
            [Key]
            public int Id { get; set; }
            public string Status { get; set; }
            public int AmountPassenger { get; set; }
            public int Maxweight { get; set; }    
            public string Company { get; set; }
       
    }
}
