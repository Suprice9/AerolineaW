using Infractructure.Data;
using Microsoft.AspNetCore.Mvc;
using Infractructure.Services;
using Domain.DTOS;
using Domain.Interface;
using System.Runtime.InteropServices;
using Infractructure.Validation;

namespace AerolineaW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplaneController : ControllerBase
    {
        private readonly DataBase _dbContext;
        private readonly IAirplaneServices _airplaneServices;
        private readonly IValidationManager _validation;

        public AirplaneController(DataBase dbContext, IAirplaneServices airplaneServices, IValidationManager validation)
        {
            _dbContext = dbContext;
            _airplaneServices = airplaneServices;
            _validation = validation;
        }

        [HttpGet]
        public async Task<IActionResult> GetAirplane()
        {
            
            return Ok(await _airplaneServices.GetAiplanes());
        }

        [HttpPost]
        public async Task<IActionResult> AddAirplane(AirplaneDto addAirplane)
        {
            try
            {
                var Airplane = await _validation.ValidateAirplaneAsync(addAirplane);

                if (!Airplane.IsValid)
                {
                    return BadRequest(Airplane.Errors.ToStringList());
                }
                await _airplaneServices.MapAirplaneObject(addAirplane);

                return Ok("Se ha creado correctamente");

            }
            catch (Exception e)
            {

                return StatusCode(500,e);
            }
           
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteAirplane(int Code)
        {
            try
            {
                var result =await _airplaneServices.DeleteAirplane(Code);

                if (result!= "Hubo un error")
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