namespace SocialO.WebApi.Models.Posts;

public class GetPostDto
{
	public string AuthorName { get; set; }
	public string AuthorUsername { get; set; }
	public int PostId { get; set; }
	public string Content { get; set; }
	public DateTime DatePosted { get; set; }
	public int AuthorId { get; set; }
	public int CommentCount { get; set; }
	public int FavoriteCount { get; set; }
}