using System.ComponentModel.DataAnnotations;

namespace WannabeRedditShared.Domain.Models;

public class Post
{
    [Key]
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public User? Author { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }

    public Post(string title, string body, int authorId)
    {
        Title = title;
        Body = body;
        AuthorId = authorId;
    }
}
