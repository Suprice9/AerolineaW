using Infractructure.Data;
using Domain.DTOS;
using Domain.Interface;
using Infractructure.Services;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using Infractructure.Validation;


namespace AerolineaW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly DataBase _dbContext;
        private readonly IPassengerServices _passengerServices;
        private readonly IValidationManager _validation;

        public PassengerController(DataBase dbContext, IPassengerServices passengerServices, IValidationManager validation)
        {
            _dbContext = dbContext;
            _passengerServices = passengerServices;
            _validation = validation;
        }


        [HttpGet]
        public async Task<IActionResult> GetPassenger()
        {
            try
            {
                return Ok(await _passengerServices.GetPassenger());
            }
            catch (Exception e)
            {

                return StatusCode(500, e);
            }
           
        }


        [HttpPost]
        public async Task<IActionResult> AddPassenger(PassengerDto addPassenger)
        {
            try
            {
                var passenger = await _validation.ValidationPassenger(addPassenger);

                if (!passenger.IsValid)
                {
                    return BadRequest(passenger.Errors.ToStringList());
                }

                await _passengerServices.MapPassengerObject(addPassenger);

                return Ok("Creado exitosamente");

            }
            catch (Exception e)
            {

                return StatusCode(500, e);
            }

        }

        [HttpDelete]
        public async Task<IActionResult> DeletePassenger(int Code)
        {
            try
            {
                var result = await _passengerServices.DeletePassenger(Code);

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

