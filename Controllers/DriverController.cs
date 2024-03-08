using f1api.DTOs;
using f1api.Models;
using f1api.Service;
using f1api.Service.IService;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace F1api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        private IValidator<Driver> _driverValidator;
        public DriverController(IDriverService driverService, IValidator<Driver> validator)
        {
          _driverValidator= validator;
            _driverService = driverService;
        }
        // GET: api/<DriverController>
        [HttpGet]
        public async   Task<IActionResult> GetAll()
        {
            try
            {
                Debug.Print("Driver:  debug");
                var ListDrivers =await  _driverService.GetAll();

                return Ok(ListDrivers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try{
                var driverToGet = await _driverService.GetById(id);
                return Ok(driverToGet); 
            }catch (Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Cards")]
        public async Task<IActionResult> GetAllCards()
        {
            try
            {
                var ListDrivers = await _driverService.GetAllCardDrivers();

                return Ok(ListDrivers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

     
      

        // POST api/<DriverController>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Driver driver)
        {
            try
            {
                var validationResult =await  _driverValidator.ValidateAsync(driver);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }
                await _driverService.Create(driver);
                return Ok(driver);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<DriverController>/5
        [HttpPut("{id:int}")]
        public async  Task<IActionResult> Put(Driver driver,int id)
        {
            try
            {
             
               var validationResult = await _driverValidator.ValidateAsync(driver);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }
                await _driverService.Update(driver, id);
                return Ok(driver);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<DriverController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _driverService.Delete(new Driver { Id = id });
                return Ok("The driver with the ID: " + id + " has been deleted.");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
