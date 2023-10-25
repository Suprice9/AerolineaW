using Microsoft.AspNetCore.Mvc;
using Domain.Modelo;
using Microsoft.EntityFrameworkCore;
using Infractructure.Data;
using Domain.DTOS;
using Mapster;
using Domain.Interface;

namespace Infractructure.Services
{
    public class AirplaneServices:IAirplaneServices
    {
        private readonly DataBase _dbContext;

        public AirplaneServices(DataBase dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<Airplane>> GetAiplanes()
        {
            var airplane = await _dbContext.Airplane
             .ToListAsync();

            return airplane;
        }

        public async Task MapAirplaneObject(AirplaneDto airplaneD)
        {

            var result = airplaneD.Adapt<Airplane>();
            result.Status = "En Tierra";
            await _dbContext.Airplane.AddAsync(result);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<string> DeleteAirplane(int id)
        {
            var airplane = await _dbContext.Airplane.FindAsync(id);

            if (airplane != null)
            {
                _dbContext.Remove(airplane);
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
