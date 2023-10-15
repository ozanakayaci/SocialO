using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IPostFavoriteManager _favoriteManager;

        public PostFavoritesController(SqlDBContext context, IPostFavoriteManager favoriteManager)
        {
            _context = context;
            this._favoriteManager = favoriteManager;
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
        [HttpPost("[action]")]
        public async Task<ActionResult<bool>> PostPostFavorite(int postId, int userId)
        {

            if (postId != null && userId != null)
            {
                PostFavorite relation = await _favoriteManager.GetBy(
                     p => (p.PostId == postId && p.UserId == userId)
                 );

                if (relation != null)
                {
                    _favoriteManager.DeleteAsync(relation);

                    return Ok(false);
                }

                PostFavorite followerRelationship = new PostFavorite
                {
                    PostId = postId,
                    UserId = userId,
                };

                int result = await _favoriteManager.InsertAsync(followerRelationship);

                return Ok(true);


            }
            return BadRequest();
        }

        //username, email var mı
        [HttpGet("[action]")]
        public async Task<ActionResult<bool>> IsLiked(int postId,int userId )
        {
            

            var favoriteExist = _favoriteManager.GetBy(x=>x.UserId == userId && x.PostId == postId).Result !=null;

            if (!favoriteExist)
            {
                return Ok(false);
            }




            return Ok(true);
        }

    }
}
