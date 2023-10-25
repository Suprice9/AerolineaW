using Domain.Interface;
using Domain.Modelo;
using Infractructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.DTOS;
using Mapster;

namespace Infractructure.Services
{
    public class AirportServices:IAirportServices
    {
        private readonly DataBase _dbContext;

        public AirportServices(DataBase dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Airport1>> GetAirportDeparture()
        {
            var airport = await _dbContext.Airport1
           .ToListAsync();

            return airport;
        }

        public async Task<List<Airport2>> GetAirportArrival()
        {
            var airport = await _dbContext.Airport2
           .ToListAsync();

            return airport;
        }

        public async Task AddAirportDeparture(AirportDto airportDto)
        {
            var result = airportDto.Adapt<Airport1>();
            await _dbContext.Airport1.AddAsync(result);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddAirportArrival(AirportDto airportDto)
        {
            var result = airportDto.Adapt<Airport2>();
            await _dbContext.Airport2.AddAsync(result);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<string> DeleteAirportDeparture(int id)
        {
            var airport = await _dbContext.Airport1.FindAsync(id);

            if (airport != null)
            {
                _dbContext.Remove(airport);
                await _dbContext.SaveChangesAsync();
                return "Se elimino correctamente";
            }
            else
            {
                return "Hubo un error";
            }
        }

        public async Task<string> DeleteAirportArrival(int id)
        {
            var airport = await _dbContext.Airport2.FindAsync(id);

            if (airport != null)
            {
                _dbContext.Remove(airport);
                await _dbContext.SaveChangesAsync();
                return "Se elimino correctamente";
            }
            else
            {
                return "Hubo un error";
            }
        }

    }
}
