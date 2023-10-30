using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialO.BL.Abstract;

namespace SocialO.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PostFavoritesController : ControllerBase
{
    private readonly IPostFavoriteManager _favoriteManager;

    public PostFavoritesController(IPostFavoriteManager favoriteManager)
    {
        _favoriteManager = favoriteManager;
    }


    [HttpPost("[action]")]
    public async Task<ActionResult<bool>> PostPostFavorite(int postId, int userId)
    {
        if (postId != 0 && userId != 0)
        {
            var isLiked = await _favoriteManager.TogglePostFavorite(postId, userId);
            return Ok(isLiked);
        }

        return BadRequest();
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<bool>> IsLiked(int postId, int userId)
    {
        var isLiked = await _favoriteManager.IsLiked(postId, userId);
        return Ok(isLiked);
    }
}