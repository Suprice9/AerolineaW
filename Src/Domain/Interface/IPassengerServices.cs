using Domain.DTOS;
using Domain.Modelo;
namespace Domain.Interface
{
    public interface IPassengerServices
    {
        Task<List<Passenger>> GetPassenger();
        Task MapPassengerObject(PassengerDto passengerDto);
        Task<string> DeletePassenger(int id);
    }
}
