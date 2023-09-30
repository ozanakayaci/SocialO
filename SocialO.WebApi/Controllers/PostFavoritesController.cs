using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialO.BL.Abstract;
using SocialO.DAL.DBContexts;
using SocialO.Entities.Concrete;
using SocialO.WebApi.Models.Favorite;

namespace SocialO.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostFavoritesController : ControllerBase
    {
        private readonly SqlDBContext _context;
		private readonly IPostFavoriteManager favoriteManager;

		public PostFavoritesController(SqlDBContext context,IPostFavoriteManager favoriteManager)
        {
            _context = context;
			this.favoriteManager = favoriteManager;
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
              

        // POST: api/PostFavorites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<bool>> PostPostFavorite([FromForm] FavoriteDto favoriteDto)
        {
            var postId = favoriteManager.GetBy(p => p.PostId == favoriteDto.PostId).Result;
            var userId = favoriteManager.GetBy(p => p.UserId == favoriteDto.UserId).Result; 

            if (postId != null && userId != null)
            {
				PostFavorite relation = await favoriteManager.GetBy(
					 p => (p.PostId == favoriteDto.PostId && p.UserId == favoriteDto.UserId)
				 );

				if (relation != null)
				{
					favoriteManager.DeleteAsync(relation);

					return true;
				}

				PostFavorite followerRelationship = new PostFavorite
				{
					PostId = favoriteDto.PostId,
					UserId = favoriteDto.UserId,
				};

				int result = await favoriteManager.InsertAsync(followerRelationship);

				return result > 0 ? true : false;


			}
            return false;
        }

       
    }
}
