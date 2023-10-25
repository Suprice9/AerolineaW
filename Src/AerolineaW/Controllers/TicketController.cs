using Infractructure.Data;
using Domain.DTOS;
using Domain.Interface;
using Infractructure.Services;
using Microsoft.AspNetCore.Mvc;
using Infractructure.Validation;

namespace AerolineaW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly DataBase _dbContext;
        private readonly ITicketServices _ticketServices;
        private readonly IValidationManager _validation;

        public TicketController(DataBase dbContext, ITicketServices ticketServices, IValidationManager validation)
        {
            _dbContext = dbContext;
            _ticketServices = ticketServices;
            _validation = validation;
        }

        [HttpGet]
        public async Task<IActionResult> GetTicket()
        {

            return Ok(await _ticketServices.GetTicket());
        }

        [HttpPost]
        public async Task<IActionResult> AddTicket(TicketDto addTicket)
        {
            try
            {
                var ticket = await _validation.ValidationTicket(addTicket);

                if (!ticket.IsValid)
                {
                    return BadRequest(ticket.Errors.ToStringList());
                }

                var remainingTime = TicketServices.RemainingTime(addTicket);

                await _ticketServices.MapTicketObject(addTicket);

                return Ok("Se ha creado exitosamente \n" + remainingTime);

            }
            catch (Exception e)
            {

                return StatusCode(500, e);
            }

        }


        [HttpPut]
        public async Task<IActionResult> UpdateStatus(int code)
        {
            try
            {
                return Ok(await _ticketServices.ModifyTicket(code));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAirplane(int Code)
        {
            try
            {
                var result = await _ticketServices.DeleteTicket(Code);

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