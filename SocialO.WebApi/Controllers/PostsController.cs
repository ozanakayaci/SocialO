using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialO.BL.Abstract;
using SocialO.BL.Models.PostModels;
using SocialO.Entities.Concrete;
using SocialO.WebApi.Models.Posts;

[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly IPostManager _postManager;

    public PostsController(IPostManager postManager)
    {
        _postManager = postManager;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<ICollection<Post>>> GetPosts()
    {
        var result = await _postManager.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("[action]/{postId}")]
    public async Task<ActionResult<GetPostDto>> GetPost(int postId)
    {
        var post = await _postManager.GetPostById(postId);

        if (post == null) return NotFound();

        return Ok(post);
    }

    [HttpGet("{followerId}")]
    public async Task<ActionResult<IEnumerable<GetPostDto>>> GetPostsByFollower(
        int followerId,
        int page = 1,
        int pageSize = 10,
        bool isOwnPost = false
    )
    {
        var posts = await _postManager.GetAllPostById(followerId, page, pageSize, isOwnPost);

        if (posts.Count() == 0) return NotFound(new { message = "Gösterilecek gönderi bulunamadı" });

        return Ok(posts);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPost(int id, Post post)
    {
        if (id != post.Id) return BadRequest();

        var result = await _postManager.UpdateAsync(post);

        if (result > 0)
            return NoContent();
        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<bool>> PostPost(PostPostDto postDto)
    {
        if (postDto.Content == null || postDto.Content == "") return BadRequest();

        var post = new Post { Content = postDto.Content, AuthorId = postDto.AuthorId };
        var result = await _postManager.InsertAsync(post);

        return result > 0;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var post = await _postManager.GetByIdAsync(id);

        if (post == null) return NotFound();

        await _postManager.DeleteAsync(post);

        return Ok();
    }
}