using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialO.DAL.DBContexts;
using SocialO.Entities.Concrete;

namespace SocialO.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostFavoritesController : ControllerBase
    {
        private readonly SqlDBContext _context;

        public PostFavoritesController(SqlDBContext context)
        {
            _context = context;
        }

        // GET: api/PostFavorites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostFavorite>>> GetPostFavorites()
        {
            if (_context.PostFavorites == null)
            {
                return NotFound();
            }
            return await _context.PostFavorites.ToListAsync();
        }

        // GET: api/PostFavorites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostFavorite>> GetPostFavorite(int id)
        {
            if (_context.PostFavorites == null)
            {
                return NotFound();
            }
            var postFavorite = await _context.PostFavorites.FindAsync(id);

            if (postFavorite == null)
            {
                return NotFound();
            }

            return postFavorite;
        }

        // POST: api/PostFavorites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PostFavorite>> PostPostFavorite(PostFavorite postFavorite)
        {
            if (_context.PostFavorites == null)
            {
                return Problem("Entity set 'SqlDBContext.PostFavorites'  is null.");
            }
            _context.PostFavorites.Add(postFavorite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostFavorite", new { id = postFavorite.Id }, postFavorite);
        }

        // DELETE: api/PostFavorites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostFavorite(int id)
        {
            if (_context.PostFavorites == null)
            {
                return NotFound();
            }
            var postFavorite = await _context.PostFavorites.FindAsync(id);
            if (postFavorite == null)
            {
                return NotFound();
            }

            _context.PostFavorites.Remove(postFavorite);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
