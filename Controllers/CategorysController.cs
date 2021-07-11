using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bookings.Data;
using Bookings.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookings.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private readonly DataContext _context;
        public CategorysController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("categoryList")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategoryBookings()
        {
            return await _context.Categories
            .Include(x => x.Hotels)
            .Include(x => x.Cars)
            .AsSplitQuery()
            .ToListAsync();
        }

        // [HttpGet("cars")]
        // public ActionResult<IEnumerable<Category>> GetCategoryBookingsCars()
        // {
        //     return _context.Categories.Include(x => x.Cars).ToList();
        // }

        //GetCategoryBookingsCars

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            try
            {
                return await _context.Categories.AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Acesso a categoria nao encontrada");
            }
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            try
            {
                var category = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(p => p.CategoryId == id);
                if (category == null)
                {
                    return NotFound($"Categoria com {id} não foi encontrada!");
                }
                return category;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Acesso a categoria nao encontrada");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Category category)
        {
            try
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();

                return new CreatedAtRouteResult("GetCategory", new { id = category.CategoryId }, category);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Acesso a categoria nao encontrada");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> Put(int id, [FromBody] Category category)
        {
            try
            {
                if (id != category.CategoryId)
                {
                    return BadRequest($"Não foi possivel atualizar a categoria por id={id}");
                }

                _context.Entry(category).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok("Categoria foi atualizada!");
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Acesso a categoria nao encontrada");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> Delete(int id)
        {
            try
            {
                var category = await _context.Categories.FirstOrDefaultAsync(p => p.CategoryId == id);

                if (category == null)
                {
                    return BadRequest();
                }

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return category;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}