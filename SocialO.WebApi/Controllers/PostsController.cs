using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialO.BL.Abstract;
using SocialO.BL.Concrete;
using SocialO.DAL.DBContexts;
using SocialO.Entities.Concrete;
using SocialO.BL.Models.PostModels;
using SocialO.WebApi.Models.Posts;

namespace SocialO.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostsController : ControllerBase
    {
        private readonly IPostManager _postManager;
        private readonly IUserManager _userManager;
		private readonly SqlDBContext _context;


        public PostsController(SqlDBContext context)
        {
            _context = context;
            _postManager = new PostManager();
            _userManager = new UserManager();
		}

        // GET: api/Posts
        [HttpGet("[action]")]
        public async Task<ActionResult<ICollection<Post>>> GetPosts()
        {
            if (_postManager.GetAllAsync() == null)
            {
                return NotFound();
            }

            var result = await _postManager.GetAllAsync();

            return new ActionResult<ICollection<Post>>(result);
        }

        // GET: api/Posts/5
        [HttpGet("[action]/{postId}")]
        public async Task<ActionResult<GetPostDto>> GetPost(int postId)
        {
            if (_context.Posts == null)
            {
                return NotFound();
            }

            var post = await _postManager.GetPostById(postId);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        //takip edilen kullanıcıların attığı postları getiriyor
        [HttpGet("{followerId}")]
        public async Task<ActionResult<IEnumerable<GetPostDto>>> GetPostsByFollower(
            int followerId,
            int page = 1,
            int pageSize = 10,
            bool isOwnPost = false
        )
        {
            try
            {

	            var user = _userManager.GetByIdAsync(followerId);

	            if (user == null)
	            {
		            return NotFound();
	            }

                var posts = await _postManager.GetAllPostById(
                    followerId,
                    page,
                    pageSize,
                    isOwnPost
                );

                if ( posts.Count() == 0)
                {
                    return NotFound(new { message = "Gösterilecek gönderi bulunamadı" });
                }

                return Ok(posts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //Gönderi oluşturduğumuz method
        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<bool>> PostPost(PostPostDto postDto)
        {
            if (postDto.Content == null || postDto.Content == "")
            {
                return BadRequest();
            }
            Post post = new Post { Content = postDto.Content, AuthorId = postDto.AuthorId, };

            int result = await _postManager.InsertAsync(post);

            return result > 0 ? true : false;
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = _postManager.GetByIdAsync(id).Result;

            if (post == null)
            {
                return NotFound();
            }

            _postManager.DeleteAsync(post);

            return Ok();
        }

        private bool PostExists(int id)
        {
            return (_context.Posts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
