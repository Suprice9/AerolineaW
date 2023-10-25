using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Infractructure.Data;
using Infractructure.Services;

namespace AerolineaW.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DummyController : ControllerBase
    {
        private readonly DummyDataServices dummydata;

        public DummyController(DataBase context)
        {
            dummydata = new(context);
        }

        [HttpGet]
        public async Task<IActionResult> GetFakeData(int increment)
        {
            try
            {
                await dummydata.DatosDummy(increment);
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(500, e);
            }
        }
    }
}
