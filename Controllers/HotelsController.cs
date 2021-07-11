using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookings.Data;
using Bookings.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookings.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly DataContext _context;
        public HotelsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> Get()
        {
            return await _context.Hotels.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id}", Name = "GetHotel")]
        public async Task<ActionResult<Hotel>> Get(int id)
        {
            var hotel = await _context.Hotels.AsNoTracking().FirstOrDefaultAsync(p => p.HotelId == id);
            if (hotel == null)
            {
                return NotFound();
            }
            return hotel;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Hotel hotel)
        {
            await _context.Hotels.AddAsync(hotel);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetHotel", new { id = hotel.HotelId }, hotel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Hotel>> Put(int id, [FromBody] Hotel hotel)
        {
            if (id != hotel.HotelId)
            {
                return BadRequest();
            }
            
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> Delete(int id)
        {
            var hotel = _context.Hotels.FirstOrDefault(p => p.HotelId == id);

            if (hotel == null)
            {
                return NotFound();
            }

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }
    }
}