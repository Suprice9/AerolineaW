using Domain.DTOS;
using Domain.Modelo;
namespace Domain.Interface
{
    public interface IAirportServices
    {
        Task<List<Airport1>> GetAirportDeparture();

        Task<List<Airport2>> GetAirportArrival();

        Task AddAirportDeparture(AirportDto airportDto);

        Task AddAirportArrival(AirportDto airportDto);

        Task<string> DeleteAirportDeparture(int id);

        Task<string> DeleteAirportArrival(int id);
    }
}
