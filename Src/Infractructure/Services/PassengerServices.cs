using Domain.DTOS;
using Domain.Interface;
using Domain.Modelo;
using Infractructure.Data;
using Microsoft.EntityFrameworkCore;
using Mapster;

namespace Infractructure.Services
{
    public class PassengerServices:IPassengerServices
    {

        private readonly DataBase _dbContext;

        public PassengerServices(DataBase dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Passenger>> GetPassenger() {

            var Passenger = await _dbContext.Passenger
           .ToListAsync();

            return Passenger;

        }

       public async Task MapPassengerObject(PassengerDto passengerDto)
        {

            var result = passengerDto.Adapt<Passenger>();
            await _dbContext.Passenger.AddAsync(result);
            await _dbContext.SaveChangesAsync();
        }

       public async Task<string> DeletePassenger(int id)
        {
            var passenger = await _dbContext.Passenger.FindAsync(id);

            if (passenger != null)
            {
                _dbContext.Remove(passenger);
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
