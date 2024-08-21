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
    public class CommentsController : ControllerBase
    {
        private readonly ResolutionsAndCommentsDbContext _context;

        public CommentsController(ResolutionsAndCommentsDbContext context)
        {
            _context = context;
        }

        // GET api/comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            return await _context.Comments.Find(c => true).ToListAsync();
        }

        // GET api/comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(string id)
        {
            var comment = await _context.Comments.Find(c => c.Id == id).FirstOrDefaultAsync();
            if (comment == null)
            {
                return NotFound();
            }
            return comment;
        }

        // POST api/comments
        [HttpPost]
        public async Task<ActionResult<Comment>> CreateComment(Comment comment)
        {
            await _context.Comments.InsertOneAsync(comment);
            return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment);
        }

        // PUT api/comments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(string id, Comment comment)
        {
            var filter = Builders<Comment>.Filter.Eq(c => c.Id, id);
            await _context.Comments.ReplaceOneAsync(filter, comment);
            return NoContent();
        }

        // DELETE api/comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(string id)
        {
            var filter = Builders<Comment>.Filter.Eq(c => c.Id, id);
            await _context.Comments.DeleteOneAsync(filter);
            return NoContent();
        }
    }
}