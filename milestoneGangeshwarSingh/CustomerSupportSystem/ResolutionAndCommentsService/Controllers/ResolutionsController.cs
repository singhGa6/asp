using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ResolutionAndCommentsService.Data;
using ResolutionAndCommentsService.models;
using ResolutionsAndCommentsService.Data;
using ResolutionsAndCommentsService.Models;

namespace ResolutionsAndCommentsService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResolutionsController : ControllerBase
    {
        private readonly ResolutionsAndCommentsDbContext _context;

        public ResolutionsController(ResolutionsAndCommentsDbContext context)
        {
            _context = context;
        }

        // GET api/resolutions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resolution>>> GetResolutions()
        {
            return await _context.Resolutions.Find(r => true).ToListAsync();
        }

        // GET api/resolutions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Resolution>> GetResolution(string id)
        {
            var resolution = await _context.Resolutions.Find(r => r.Id == id).FirstOrDefaultAsync();
            if (resolution == null)
            {
                return NotFound();
            }
            return resolution;
        }

        // POST api/resolutions
        [HttpPost]
        public async Task<ActionResult<Resolution>> CreateResolution(Resolution resolution)
        {
            await _context.Resolutions.InsertOneAsync(resolution);
            return CreatedAtAction(nameof(GetResolution), new { id = resolution.Id }, resolution);
        }

        // PUT api/resolutions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResolution(string id, Resolution resolution)
        {
            var filter = Builders<Resolution>.Filter.Eq(r => r.Id, id);
            await _context.Resolutions.ReplaceOneAsync(filter, resolution);
            return NoContent();
        }

        // DELETE api/resolutions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResolution(string id)
        {
            var filter = Builders<Resolution>.Filter.Eq(r => r.Id, id);
            await _context.Resolutions.DeleteOneAsync(filter);
            return NoContent();
        }
    }
}