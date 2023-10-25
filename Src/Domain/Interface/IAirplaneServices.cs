using Domain.DTOS;
using Domain.Modelo;

namespace Domain.Interface
{
    public interface IAirplaneServices
    {
       Task<List<Airplane>> GetAiplanes();
       Task MapAirplaneObject(AirplaneDto airplaneD);

       Task<string> DeleteAirplane(int id);

    }
}
