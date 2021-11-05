using Microsoft.AspNetCore.Mvc;
using Business.Abstract;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private ICarService iCarService;

        public CarController(ICarService iCarService)
        {
            this.iCarService = iCarService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = iCarService.GetAll();
            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result.Message);
        }
    }
}
