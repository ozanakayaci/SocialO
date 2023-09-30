using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialO.BL.Abstract;
using SocialO.BL.Concrete;
using SocialO.DAL.DBContexts;
using SocialO.Entities.Concrete;
using SocialO.WebApi.Models.Posts;

namespace SocialO.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostsController : ControllerBase
    {
        private readonly IPostManager _postManager;
        private readonly SqlDBContext _context;

        public PostsController(SqlDBContext context)
        {
            _context = context;
            _postManager = new PostManager();
        }

        // GET: api/Posts
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            if (_context.Posts == null)
            {
                return NotFound();
            }
            return await _context.Posts.ToListAsync();
        }

        // GET: api/Posts/5
        [HttpGet("[action]/{postId}")]
        public async Task<ActionResult<GetPostDto>> GetPost(int postId)
        {
            if (_context.Posts == null)
            {
                return NotFound();
            }

            //post id si postId olan postu getiriyoruz GetPostDto ya map ediyoruz
            var post = await _context.Posts
                .Where(p => p.Id == postId)
                .Select(
                    p =>
                        new GetPostDto
                        {
                            AuthorName = p.User.UserProfile.FirstName,
                            AuthorUsername = p.User.Username,
                            PostId = p.Id,
                            Content = p.Content,
                            DatePosted = p.DatePosted,
                            AuthorId = p.AuthorId,
                            CommentCount = p.PostComments.Count,
                            FavoriteCount = p.PostFavorites.Count
                        }
                )
                .FirstOrDefaultAsync();

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
                if (isOwnPost)
                {
                    var ownPosts = await _context.Posts
                        .Where(p => p.User.Following.Any(f => f.UserId == followerId))
                        .OrderByDescending(p => p.DatePosted)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .Select(
                            p =>
                                new GetPostDto
                                {
                                    AuthorName = p.User.UserProfile.FirstName,
                                    AuthorUsername = p.User.Username,
                                    PostId = p.Id,
                                    Content = p.Content,
                                    DatePosted = p.DatePosted,
                                    AuthorId = p.AuthorId,
                                    CommentCount = p.PostComments.Count,
                                    FavoriteCount = p.PostFavorites.Count
                                }
                        )
                        .ToListAsync();

                    if (ownPosts == null || ownPosts.Count == 0)
                    {
                        return NotFound();
                    }

                    return Ok(ownPosts);
                }
                var posts = await _context.Posts
                    .Where(p => p.User.Following.Any(f => f.FollowerId == followerId))
                    .OrderByDescending(p => p.DatePosted)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(
                        p =>
                            new GetPostDto
                            {
                                AuthorName = p.User.UserProfile.FirstName,
                                AuthorUsername = p.User.Username,
                                PostId = p.Id,
                                Content = p.Content,
                                DatePosted = p.DatePosted,
                                AuthorId = p.AuthorId,
                                CommentCount = p.PostComments.Count,
                                FavoriteCount = p.PostFavorites.Count
                            }
                    )
                    .ToListAsync();

                if (posts == null || posts.Count == 0)
                {
                    return NotFound();
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
        public async Task<ActionResult<bool>> PostPost( PostPostDto postDto)
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
            if (_context.Posts == null)
            {
                return NotFound();
            }
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostExists(int id)
        {
            return (_context.Posts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
