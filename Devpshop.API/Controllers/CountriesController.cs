using Devpshop.API.Data;
using Devpshop.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Devpshop.API.Controllers
{
    [ApiController]
    [Route("/api/countries")]
    public class CountriesController: ControllerBase
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync() 
        {
            return Ok(await _context.Countries.ToListAsync());
        }

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetAsync(int id)
		{
            var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
            if(country == null)
            {
                return NotFound();
            }
			return Ok(country);
		}

		[HttpPost]
        public async Task<ActionResult> PostAsync(Country country)
        {
            _context.Add(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }

		[HttpPut]
		public async Task<ActionResult> PtAsync(Country country)
		{
			_context.Update(country);
			await _context.SaveChangesAsync();
			return Ok(country);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
			if (country == null)
			{
				return NotFound();
			}

			_context.Remove(country);
			await _context.SaveChangesAsync();
			return NoContent();
		}
	}


}
