using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using N_TierArch.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N_TierArch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        static List<Car> Cars = new List<Car> {
        new Car() { Id = 1, Name = "S685", Color = "Red", Model = "BMW" },
        new Car() { Id = 2, Name = "S6", Color = "Blue", Model = "BMW" },
        new Car() { Id = 3, Name = "GLC", Color = "White", Model = "Mercedes" },
        new Car() { Id = 4, Name = "maybach ", Color = "Black", Model = "Mercedes" },
        };

        public ILogger Logger { get; }
        public Request Req { get; }

        public CarsController(ILogger<CarsController> logger, Request request)
        {
            Logger = logger;
            Req = request;
        }


        // GET: api/<CarsController>
        [HttpGet]
        public IActionResult Get()
        {
            Logger.LogInformation($"Get All Cars");
            return Ok(Cars);
        }

        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Logger.LogInformation($"Get Car By ID {id}");
            var car = Cars.FirstOrDefault(c => c.Id == id);
            return car == null ? NotFound() : Ok(car);
        }

        // POST api/<CarsController>
        [HttpPost]
        [Route("v1")]
        public IActionResult PostV1([FromBody] Car car)
        {
            car.Id = Cars.Count() + 1;
            Logger.LogInformation($"Post a Car With ID {car.Id}");
            car.Type = "Gas";
            Cars.Add(car);
            return CreatedAtAction(nameof(Get), new { id = car.Id }, car);
        }

        [HttpPost]
        [Route("v2")]
        [TypeFilterAttribute]
        public IActionResult PostV2([FromBody] Car car)
        {
            car.Id = Cars.Count() + 1;
            Logger.LogInformation($"Post a Car With ID {car.Id}");
            Cars.Add(car);
            return CreatedAtAction(nameof(Get), new { id = car.Id }, car);
        }

        // PUT api/<CarsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Car ModifiedCar)
        {
            Logger.LogInformation($"Put a Car With ID {id}");
            if (id != ModifiedCar.Id) return BadRequest();

            var carIndex = Cars.IndexOf(ModifiedCar);
            if (carIndex == -1) return NotFound();
            Cars[carIndex] = ModifiedCar;
            return NoContent();

        }

        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Logger.LogInformation($"Delete a Car With ID {id}");
            var car = Cars.FirstOrDefault(c => c.Id == id);
            if (car == null) return NotFound();
            Cars.Remove(car);
            return NoContent();
        }

        [HttpGet]
        [Route("Counter")]
        public IActionResult GetCount()
        { 
          return  Ok(Req.Count);
        } 
    }

}
