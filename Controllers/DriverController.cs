using f1api.DTOs;
using f1api.Models;
using f1api.Service;
using f1api.Service.IService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace F1api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        public readonly IDriverService _driverService;
        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }
        // GET: api/<DriverController>
        [HttpGet]
        public Task<List<Driver>>  GetAll()
        {
           var ListDrivers= _driverService.GetAll();

            return ListDrivers;
        }

        [HttpGet("Cards")]
        public async Task<IEnumerable<CarDriverDto>> GetAllCards()
        {
            var ListDrivers = await _driverService.GetAllCardDrivers();

            return ListDrivers;
        }

        // GET api/<DriverController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DriverController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DriverController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DriverController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
