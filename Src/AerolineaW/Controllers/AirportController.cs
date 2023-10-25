using Domain.Interface;
using Infractructure.Data;
using Microsoft.AspNetCore.Mvc;
using Infractructure.Services;
using Domain.DTOS;
using Infractructure.Validation;

namespace AerolineaW.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly DataBase _dbContext;
        private readonly IAirportServices _airportServices;
        private readonly IValidationManager _validation;

        public AirportController(DataBase dbContext, IAirportServices airportServices,IValidationManager validation)
        {
            _dbContext = dbContext;
            _airportServices = airportServices;
            _validation = validation;
        }


        [HttpGet("Departure")]
        public async Task<IActionResult> GetAirportDeparture()
        {

            return Ok(await _airportServices.GetAirportDeparture());
        }

        [HttpGet("Arrival")]
        public async Task<IActionResult> GetAirportArrival()
        {

            return Ok(await _airportServices.GetAirportArrival());
        }

        [HttpPost("Departure")]
        public async Task<IActionResult> AddAirportDeparture(AirportDto addAirport)
        {
            try
            {
                var Airport = await _validation.ValidationAirport(addAirport);

                if (!Airport.IsValid)
                {
                    return BadRequest(Airport.Errors.ToStringList());
                }

                await _airportServices.AddAirportDeparture(addAirport);

                return Ok("Se ha agregado exitosamente");

            }
            catch (Exception e)
            {

                return StatusCode(500, e);
            }

        }

        [HttpPost("Arrival")]
        public async Task<IActionResult> AddAirportArrival(AirportDto addAirport)
        {
            try
            {
                var Airport = await _validation.ValidationAirport(addAirport);

                if (!Airport.IsValid)
                {
                    return BadRequest(Airport.Errors.ToStringList());
                }

                await _airportServices.AddAirportArrival(addAirport);
                return Ok("Ha sido creado exitosamente");

            }
            catch (Exception e)
            {

                return StatusCode(500, e);
            }

        }


        
        [HttpDelete ("Departure")]
        public async Task<IActionResult> DeleteAirportDeparture( int Code)
        {
            try
            {
                var result = await _airportServices.DeleteAirportDeparture(Code);

                if (result != "Hubo un error")
                {
                    return Ok(result);
                }
                else
                {
                    {
                        return BadRequest();
                    }
                }

            }
            catch (Exception e)
            {

                return StatusCode(500, e);
            }
        }

        [HttpDelete ("Arrival")]
        
       public async Task<IActionResult> DeleteAirportArrival(int code)
        {
            try
            {
                var result = await _airportServices.DeleteAirportArrival(code);

                if (result != "Hubo un error")
                {
                    return Ok(result);
                }
                else
                {
                    {
                        return BadRequest();
                    }
                }

            }
            catch (Exception e)
            {

                return StatusCode(500, e);
            }
        }
    }
}
