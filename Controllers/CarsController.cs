using System.Collections.Generic;
using System.Threading.Tasks;
using Bookings.Data;
using Bookings.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookings.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly DataContext _context;
        public CarsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> Get()
        {
            return await _context.Cars.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id}", Name = "GetCar")]
        public async Task<ActionResult<Car>> Get(int id)
        {
            var car = await _context.Cars.AsNoTracking().FirstOrDefaultAsync(p => p.CarId == id);
            if (car == null)
            {
                return NotFound("ID referente ao carro não foi encontrada!");
            }
            return car;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetCar", new { id = car.CarId }, car);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Car>> Put(int id, [FromBody] Car car)
        {
            if (id != car.CarId)
            {
                return BadRequest();
            }
            _context.Entry(car).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> Delete(int id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(p => p.CarId == id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return car;
        }
    }

}